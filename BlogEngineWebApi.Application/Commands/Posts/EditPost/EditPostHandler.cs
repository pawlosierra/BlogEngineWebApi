using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Commands.Posts.EditPost
{
  public class EditPostHandler : IRequestHandler<EditPost, Post>
  {
    private readonly IPostRepository _postRepository;
    private readonly ICategoryRepository _categoryRepository;
    public EditPostHandler(
      IPostRepository postRepository,
      ICategoryRepository categoryRepository)
    {
      _postRepository = postRepository;
      _categoryRepository = categoryRepository;
    }
    public async Task<Post> Handle(EditPost request, CancellationToken cancellationToken)
    {
      if (await _postRepository.GetPostByTitle(request.Title) == null)
      {
        throw new PostException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                "The post you want to edit does not exist.");
      }
      if (await _postRepository.GetPostByTitle(request.Post.Title) != null)
      {
        throw new PostException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                "The title of the post you want to edit already exists, please try with another title.");
      }
      if (_categoryRepository.GetCategoryByTitle(request.Post.Category) == null)
      {
        throw new CategoryException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                   "The title of the category you want to edit not exists, please try with another title.");
      }
      return await _postRepository.EditPost(request.Post, request.Title);
    }
  }
}

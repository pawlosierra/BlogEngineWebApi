using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Commands.Posts.AddPost
{
  public class AddPostHandler : IRequestHandler<AddPost, Post>
  {
    private readonly IPostRepository _postRepository;
    private readonly ICategoryRepository _categoryRepository;
    public AddPostHandler(
      IPostRepository postRepository,
      ICategoryRepository categoryRepository)
    {
      _postRepository = postRepository;
      _categoryRepository = categoryRepository;
    }
    public async Task<Post> Handle(AddPost request, CancellationToken cancellationToken)
    {
      if ( await _postRepository.GetPostByTitle(request.Post.Title) != null)
      {
        throw new PostException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                "The title of the post you want to enter already exists, please try with another title.");
      }
      if (_categoryRepository.GetCategoryByTitle(request.Post.Category) == null)
      {
        throw new CategoryException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                    "The category you want to select for your post does not exist. Please try another category title.");
      }
      return await _postRepository.AddPost(request.Post);
    }
  }
}

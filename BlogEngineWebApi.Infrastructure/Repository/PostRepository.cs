using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using BlogEngineWebApi.Infrastructure.Data;
using BlogEngineWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Infrastructure.Repository
{
  public class PostRepository : IPostRepository
  {
    private readonly BlogEngineContext _blogEngineContext;
    private readonly IMapper _mapper;
    public PostRepository(
      BlogEngineContext blogEngineContext,
      IMapper mapper)
    {
      _blogEngineContext = blogEngineContext;
      _mapper = mapper;
    }

    public async Task<Post> AddPost(Post postRequest)
    {
      postRequest.Id = Guid.NewGuid();
      postRequest.IdCategory = _blogEngineContext.CategoryModels.Where(x => x.Title == postRequest.Category).FirstOrDefault().Id;
      await _blogEngineContext.PostModels.AddAsync(_mapper.Map<PostModel>(postRequest));
      await _blogEngineContext.SaveChangesAsync();
      return postRequest;
    }

    public async Task<Post> EditPost(Post postRequest, string title)
    {
      var post = _blogEngineContext.PostModels.Where(x => x.Title == title).FirstOrDefault();
      var category = _blogEngineContext.CategoryModels.Where(x => x.Title == postRequest.Category).FirstOrDefault();
      post.Title = postRequest.Title;
      post.IdCategory = category.Id;
      post.PublicationDate = postRequest.PublicationDate;
      post.Content = postRequest.Content;
      _blogEngineContext.PostModels.Update(post);
      await _blogEngineContext.SaveChangesAsync();
      return _mapper.Map<Post>(post);
    }

    public async Task<Post> GetPostByTitle(string title)
    {
      var post = _blogEngineContext.PostModels
        .Include(x => x.IdCategoryNavigation)
        .Where(x => x.Title == title)
        .FirstOrDefault();
      return _mapper.Map<Post>(post);
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
      var post = await _blogEngineContext.PostModels
        .Include(x => x.IdCategoryNavigation)
        .Where(x => x.PublicationDate <= DateTime.Now)
        .OrderByDescending(x => x.PublicationDate)
        .ToListAsync();
      return _mapper.Map<IEnumerable<Post>>(post);
    }
  }
}

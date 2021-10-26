using BlogEngineWebApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Domain.Repositories
{
  public interface IPostRepository
  {
    Task<IEnumerable<Post>> GetPosts();
    Task<Post> GetPostByTitle(string title);
    Task<Post> AddPost(Post postRequest);
    Task<Post> EditPost(Post postRequest, string title);
  }
}

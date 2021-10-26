using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Commands.Posts.AddPost
{
  public class AddPost : IRequest<Post>
  {
    public Post Post { get; set; }
    public string Title { get; set; }
    public AddPost(
      Post post)
    {
      Post = post;
    }
  }
}

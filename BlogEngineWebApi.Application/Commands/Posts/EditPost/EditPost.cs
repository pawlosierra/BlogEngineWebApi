using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Commands.Posts.EditPost
{
  public class EditPost : IRequest<Post>
  {
    public Post Post { get; set; }
    public string Title { get; set; }
    public EditPost(
      Post post,
      string title)
    {
      Post = post;
      Title = title;
    }
  }
}

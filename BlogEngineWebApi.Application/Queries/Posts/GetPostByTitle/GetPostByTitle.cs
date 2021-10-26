using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Queries.Posts.GetPostByTitle
{
  public class GetPostByTitle : IRequest<Post>
  {
    public string Title { get; set; }
    public GetPostByTitle(
      string title)
    {
      Title = title;
    }
  }
}

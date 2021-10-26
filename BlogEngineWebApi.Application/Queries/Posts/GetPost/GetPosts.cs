using BlogEngineWebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace BlogEngineWebApi.Application.Queries.Posts.GetPost
{
  public class GetPosts : IRequest<IEnumerable<Post>>
  {
  }
}

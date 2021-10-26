using BlogEngineWebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace BlogEngineWebApi.Application.Queries.Categories.GetPostsByCategoryTitle
{
  public class GetPostsByCategoryTitle : IRequest<IEnumerable<Post>>
  {
    public string Title { get; set; }
    public GetPostsByCategoryTitle(
      string title)
    {
      Title = title;
    }
  }
}

using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Queries.Categories.GetCategoryByTitle
{
  public class GetCategoryByTitle : IRequest<Category>
  {
    public string Title { get; set; }
    public GetCategoryByTitle(
      string title)
    {
      Title = title;
    }
  }
}

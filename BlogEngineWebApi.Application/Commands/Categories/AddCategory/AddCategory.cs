using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Commands.Categories.AddCategory
{
  public class AddCategory : IRequest<Category>
  {
    public Category Category { get; set; }
    public AddCategory(
      Category category)
    {
      Category = category;
    }
  }
}

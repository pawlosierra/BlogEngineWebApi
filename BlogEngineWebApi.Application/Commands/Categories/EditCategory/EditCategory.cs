using BlogEngineWebApi.Domain.Models;
using MediatR;

namespace BlogEngineWebApi.Application.Commands.Categories.EditCategory
{
  public class EditCategory : IRequest<Category>
  {
    public Category Category { get; set; }
    public string CategoryTitle { get; set; }
    public EditCategory(
      Category category,
      string categoryTitle)
    {
      Category = category;
      CategoryTitle = categoryTitle;
    }
  }
}

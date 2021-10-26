using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Commands.Categories.EditCategory
{
  public class EditCategoryHandler : IRequestHandler<EditCategory, Category>
  {
    private readonly ICategoryRepository _categoryRepository;
    public EditCategoryHandler(
      ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    public Task<Category> Handle(EditCategory request, CancellationToken cancellationToken)
    {
      if (_categoryRepository.GetCategoryByTitle(request.CategoryTitle) == null)
      {
        throw new CategoryException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                   "The category you want to edit does not exist.");
      }
      if (_categoryRepository.GetCategoryByTitle(request.Category.Title) != null)
      {
        throw new CategoryException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                   "The title of the category you want to edit already exists, please try with another title.");
      }
      return _categoryRepository.EditCategory(request.Category, request.CategoryTitle);
    }
  }
}

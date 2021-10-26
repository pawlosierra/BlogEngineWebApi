using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Commands.Categories.AddCategory
{
  public class AddCategoryHandler : IRequestHandler<AddCategory, Category>
  {
    private readonly ICategoryRepository _categoryRepository;
    public AddCategoryHandler(
      ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public async Task<Category> Handle(AddCategory request, CancellationToken cancellationToken)
    {
      if (_categoryRepository.GetCategoryByTitle(request.Category.Title) != null)
      {
        throw new CategoryException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                   "The title of the category you want to enter already exists, please try with another title.");
      }
      return await _categoryRepository.AddCategory(request.Category);
    }
  }
}

using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Queries.Categories.GetCategories
{
  public class GetCategoriesHandler : IRequestHandler<GetCategories, IEnumerable<Category>>
  {
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoriesHandler(
      ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public async Task<IEnumerable<Category>> Handle(GetCategories request, CancellationToken cancellationToken)
    {
      return await _categoryRepository.GetCategories();
    }
  }
}

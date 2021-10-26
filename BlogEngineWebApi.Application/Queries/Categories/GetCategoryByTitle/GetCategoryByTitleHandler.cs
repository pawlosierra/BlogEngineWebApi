using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Queries.Categories.GetCategoryByTitle
{
  public class GetCategoryByTitleHandler : IRequestHandler<GetCategoryByTitle, Category>
  {
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryByTitleHandler(
      ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public async Task<Category> Handle(GetCategoryByTitle request, CancellationToken cancellationToken)
    {
      return _categoryRepository.GetCategoryByTitle(request.Title);
    }
  }
}

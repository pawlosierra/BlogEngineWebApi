using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Queries.Categories.GetPostsByCategoryTitle
{
  class GetPostsByCategoryTitleHandler : IRequestHandler<GetPostsByCategoryTitle, IEnumerable<Post>>
  {
    private readonly ICategoryRepository _categoryRepository;
    public GetPostsByCategoryTitleHandler(
      ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public async Task<IEnumerable<Post>> Handle(GetPostsByCategoryTitle request, CancellationToken cancellationToken)
    {
      if (_categoryRepository.GetCategoryByTitle(request.Title) == null)
      {
        throw new PostException("AN ERROR WAS ENCOUNTERED DURING THE REQUEST",
                                "The Post by category title that you want to find does not exist.");
      }
      return await _categoryRepository.GetPostsByCategoryTitle(request.Title);
    }
  }
}

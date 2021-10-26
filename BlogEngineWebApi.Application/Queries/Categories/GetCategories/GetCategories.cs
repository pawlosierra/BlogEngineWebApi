using BlogEngineWebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace BlogEngineWebApi.Application.Queries.Categories.GetCategories
{
  public class GetCategories : IRequest<IEnumerable<Category>>
  {
  }
}

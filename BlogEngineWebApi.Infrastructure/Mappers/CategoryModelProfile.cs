using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Infrastructure.Models;

namespace BlogEngineWebApi.Infrastructure.Mappers
{
  public class CategoryModelProfile : Profile
  {
    public CategoryModelProfile()
    {
      CreateMap<CategoryModel, Category>().ReverseMap();
    }
  }
}

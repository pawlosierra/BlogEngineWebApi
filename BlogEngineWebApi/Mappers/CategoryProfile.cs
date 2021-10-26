using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.DTOs.Categories;

namespace BlogEngineWebApi.Mappers
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      CreateMap<Category, CategoryResponse>();
      CreateMap<CategoryRequest, Category>();
    }
  }
}

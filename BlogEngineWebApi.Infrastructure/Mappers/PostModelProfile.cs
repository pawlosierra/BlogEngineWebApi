using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Infrastructure.Models;

namespace BlogEngineWebApi.Infrastructure.Mappers
{
  public class PostModelProfile : Profile
  {
    public PostModelProfile()
    {
      CreateMap<PostModel, Post>()
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.IdCategoryNavigation.Title));
      CreateMap<Post, PostModel>();
    }
  }
}

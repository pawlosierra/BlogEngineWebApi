using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.DTOs.Posts;

namespace BlogEngineWebApi.Mappers
{
  public class PostProfile : Profile
  {
    public PostProfile()
    {
      CreateMap<Post, PostResponse>();
      CreateMap<PostRequest, Post>();
    }
  }
}

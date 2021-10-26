using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Queries.Posts.GetPostByTitle
{
  public class GetPostByTitleHandler : IRequestHandler<GetPostByTitle, Post>
  {
    private readonly IPostRepository _postRepository;
    public GetPostByTitleHandler(
      IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }
    public async Task<Post> Handle(GetPostByTitle request, CancellationToken cancellationToken)
    {
      return await _postRepository.GetPostByTitle(request.Title);
    }
  }
}

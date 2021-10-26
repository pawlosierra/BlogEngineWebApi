using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Application.Queries.Posts.GetPost
{
  public class GetPostsHandler : IRequestHandler<GetPosts, IEnumerable<Post>>
  {
    private readonly IPostRepository _postRepository;
    public GetPostsHandler(
      IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
      return await _postRepository.GetPosts();
    }
  }
}

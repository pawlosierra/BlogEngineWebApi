using AutoMapper;
using BlogEngineWebApi.Application.Commands.Posts.AddPost;
using BlogEngineWebApi.Application.Commands.Posts.EditPost;
using BlogEngineWebApi.Application.Queries.Posts.GetPost;
using BlogEngineWebApi.Application.Queries.Posts.GetPostByTitle;
using BlogEngineWebApi.Domain.Exceptions;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.DTOs.Categories;
using BlogEngineWebApi.DTOs.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly ILogger<PostsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostsController(
      ILogger<PostsController> logger,
      IMediator mediator,
      IMapper mapper)
    {
      _logger = logger;
      _mediator = mediator;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetPost()
    {
      _logger.LogInformation("Getting Posts");
      var posts = await _mediator.Send(new GetPosts());
      if (!posts.Any())
      {
        return StatusCode((int)HttpStatusCode.NoContent);
      }
      return Ok(_mapper.Map<IEnumerable<PostResponse>>(posts));
    }
    [HttpGet("{title}")]
    public async Task<IActionResult> GetPostByTitle(
      [Required(ErrorMessage = "The field title is required")]
      string title)
    {
      _logger.LogInformation("Getting post by title");
      var post = await _mediator.Send(new GetPostByTitle(title));
      if (post == null)
      {
        return StatusCode((int)HttpStatusCode.NotFound);
      }
      return Ok(_mapper.Map<PostResponse>(post));
    } 
    [HttpPost]
    public async Task<IActionResult> AddPost(PostRequest postRequest)
    {
      try
      {
        _logger.LogInformation("Adding post");
        var post = await _mediator.Send(new AddPost(_mapper.Map<Post>(postRequest)));
        return Ok(_mapper.Map<PostResponse>(post));
      }
      catch (PostException ex) 
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, new PostError 
        {
          ErrorCode = ex.ErrorCode,
          Messagge = ex.Message
        });
      }
      catch (CategoryException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, new CategoryError 
        {
          ErrorCode = ex.ErrorCode,
          Message = ex.Message
        });
      }
    }
    [HttpPut]
    public async Task<IActionResult> EditPost(
      [FromQuery(Name = "title")]
      [Required(ErrorMessage = "The field title is required")]
      string title,
      PostRequest postRequest)
    {
      try
      {
        _logger.LogInformation("Editing post");
        var post = await _mediator.Send(new EditPost(_mapper.Map<Post>(postRequest), title));
        return Ok(_mapper.Map<PostResponse>(post));
      }
      catch (PostException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, new PostError 
        {
          ErrorCode = ex.ErrorCode,
          Messagge = ex.Message
        });
      }
      catch (CategoryException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, new CategoryError 
        {
          ErrorCode = ex.ErrorCode,
          Message = ex.Message
        });
      }
    }
  }
}

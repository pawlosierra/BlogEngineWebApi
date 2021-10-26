using AutoMapper;
using BlogEngineWebApi.Application.Commands.Categories.AddCategory;
using BlogEngineWebApi.Application.Commands.Categories.EditCategory;
using BlogEngineWebApi.Application.Queries.Categories.GetCategories;
using BlogEngineWebApi.Application.Queries.Categories.GetCategoryByTitle;
using BlogEngineWebApi.Application.Queries.Categories.GetPostsByCategoryTitle;
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
  public class CategoriesController : ControllerBase
  {
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CategoriesController(
      ILogger<CategoriesController> logger,
      IMediator mediator,
      IMapper mapper
      )
    {
      _logger = logger;
      _mediator = mediator;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
      _logger.LogInformation("Getting Catgories");
      var categories = await _mediator.Send(new GetCategories());
      if (!categories.Any())
      {
        return StatusCode((int)HttpStatusCode.NoContent);
      }
      return Ok(_mapper.Map<IEnumerable<CategoryResponse>>(categories));
    }
    [HttpGet("{title}")]
    public async Task<IActionResult> GetCategoryByTitle(
      [Required(ErrorMessage = "The field categoryTitle is required")]
      string title)
    {
      _logger.LogInformation("Getting category by Title");
      var category = await _mediator.Send(new GetCategoryByTitle(title));
      if (category == null)
      {
        return StatusCode((int)HttpStatusCode.NoContent);
      }
      return Ok(_mapper.Map<CategoryResponse>(category));
    }
    [HttpGet("{title}/posts")]
    public async Task<IActionResult> GetPostsByCategoryTitle(
      [Required(ErrorMessage = "The field title is required")]
      string title)
    {
      try
      {
        _logger.LogInformation("Getting posts by title of category");
        var posts = await _mediator.Send(new GetPostsByCategoryTitle(title));
        if (!posts.Any())
        {
          return StatusCode((int)HttpStatusCode.NoContent);
        }
        return Ok(_mapper.Map<IEnumerable<PostResponse>>(posts));
      }
      catch (PostException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError , new PostError 
        {
          ErrorCode = ex.ErrorCode,
          Messagge = ex.Message
        });
      }
    }
    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryRequest categoryRequest)
    {
      try
      {
        _logger.LogInformation("Adding Category");
        var category = await _mediator.Send(new AddCategory(_mapper.Map<Category>(categoryRequest)));
        return Ok(_mapper.Map<CategoryResponse>(category));
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
    public async Task<IActionResult> EditCategory(
      [FromQuery(Name = "categoryTitle")]
      [Required(ErrorMessage = "The field categoryTitle is required")]
      string categoryTitle,
      CategoryRequest categoryRequest)
    {
      try
      {
        _logger.LogInformation("Editing Category");
        var category = await _mediator.Send(new EditCategory(_mapper.Map<Category>(categoryRequest), 
                                                             categoryTitle));
        return Ok(_mapper.Map<CategoryResponse>(category));
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

using AutoFixture;
using AutoMapper;
using BlogEngineWebApi.Application.Queries.Categories.GetCategories;
using BlogEngineWebApi.Controllers;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.DTOs.Categories;
using BlogEngineWebApi.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngineWebApi.Test.Controllers
{
  public class CategoriesControllerTest 
  {
    private readonly CancellationToken _cancellationToken;
    private readonly Mock<ILogger<CategoriesController>> _loggerMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;

    private readonly CategoriesController _tested;

    public CategoriesControllerTest()
    {
      _cancellationToken = default;
      _loggerMock = new Mock<ILogger<CategoriesController>>();
      _mediatorMock = new Mock<IMediator>();

      var configuration = new MapperConfiguration(cfg => 
      {
        cfg.AddProfile<CategoryProfile>();
        cfg.AddProfile<PostProfile>();
      });
      _mapper = new Mapper(configuration);

      _fixture = new Fixture();

      _tested = new CategoriesController(_loggerMock.Object,
                                         _mediatorMock.Object,
                                         _mapper);
    }

    [Fact]
    public async Task GivenGetCategories_WhenGetCategoriesIsSuccess_ThenReturnListOfCategories()
    {
      var expectedMediatorResults = _fixture.CreateMany<Category>();

      _mediatorMock
        .Setup(x => x.Send(It.IsAny<GetCategories>(), _cancellationToken))
        .ReturnsAsync(expectedMediatorResults);

      var result = await _tested.GetCategories();

      var okResult = Assert.IsType<OkObjectResult>(result);

      var response = Assert.IsAssignableFrom<IEnumerable<CategoryResponse>>(okResult.Value);

      Assert.Equal(expectedMediatorResults.Select(x => x.Title), response.Select(x => x.Title));

      _mediatorMock
        .Verify(x => x.Send(It.IsAny<GetCategories>(), _cancellationToken));
    }
  }
}

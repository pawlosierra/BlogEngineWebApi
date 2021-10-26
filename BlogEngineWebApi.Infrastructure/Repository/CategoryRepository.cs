using AutoMapper;
using BlogEngineWebApi.Domain.Models;
using BlogEngineWebApi.Domain.Repositories;
using BlogEngineWebApi.Infrastructure.Data;
using BlogEngineWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Infrastructure.Repository
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly BlogEngineContext _blogEngineContext;
    private readonly IMapper _mapper;
    public CategoryRepository(
      BlogEngineContext blogEngineContext,
      IMapper mapper)
    {
      _blogEngineContext = blogEngineContext;
      _mapper = mapper;
    }
    public async Task<Category> AddCategory(Category categoryRequest)
    {
      categoryRequest.Id = Guid.NewGuid();
      await _blogEngineContext.CategoryModels.AddAsync(_mapper.Map<CategoryModel>(categoryRequest));
      await _blogEngineContext.SaveChangesAsync();
      return categoryRequest;

    }

    public async Task<Category> EditCategory(Category categoryRequest, string categoryTitle)
    {
      var category = _blogEngineContext.CategoryModels.Where(x => x.Title == categoryTitle).FirstOrDefault();
      category.Title = categoryRequest.Title;
      _blogEngineContext.CategoryModels.Update(category);
      await _blogEngineContext.SaveChangesAsync();
      return _mapper.Map<Category>(category);
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
      var categories = await _blogEngineContext.CategoryModels.ToListAsync();
      return _mapper.Map<IEnumerable<Category>>(categories);
    }

    public Category GetCategoryByTitle(string title)
    {
      var category = _blogEngineContext.CategoryModels
        .Where(x => x.Title == title)
        .FirstOrDefault();
      return _mapper.Map<Category>(category);
    }

    public async Task<IEnumerable<Post>> GetPostsByCategoryTitle(string title)
    {
      var category = GetCategoryByTitle(title);
      var posts = _blogEngineContext.PostModels.Where(x => x.IdCategory == category.Id).ToList();
      return _mapper.Map<IEnumerable<Post>>(posts);
    }
  }
}

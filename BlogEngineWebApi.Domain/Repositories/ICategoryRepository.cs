using BlogEngineWebApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogEngineWebApi.Domain.Repositories
{
  public interface ICategoryRepository
  {
    Task<IEnumerable<Category>> GetCategories();
    Category GetCategoryByTitle(string title);
    Task<IEnumerable<Post>> GetPostsByCategoryTitle(string title);
    Task<Category> AddCategory(Category categoryRequest);
    Task<Category> EditCategory(Category categoryRequest, string categoryTitle);
  }
}

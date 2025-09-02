using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class CategoryService
    {
        private readonly CategoryRepo _repo;

        public CategoryService(CategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            var result = await _repo.AllCategories();

            return result;
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await _repo.AddCategory(category);

            return result;
        }
    }
}

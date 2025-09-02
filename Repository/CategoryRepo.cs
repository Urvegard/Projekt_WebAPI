using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class CategoryRepo
    {
        private readonly TravelContext _context;

        public CategoryRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> AllCategories()
        {
            var result = await _context.Categories.ToListAsync();

            return result;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);

            var result = await _context.SaveChangesAsync();

            return category;
        }
    }
}

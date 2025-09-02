using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class AttractionRepo
    {
        private readonly TravelContext _context;

        public AttractionRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Attraction>> AllAttractions()
        {
            var result = await _context.Attractions.ToListAsync();

            return result;
        }

        public async Task<Attraction> AddAttraction(Attraction attraction)
        {
            await _context.Attractions.AddAsync(attraction);

            var result = await _context.SaveChangesAsync();

            return attraction;
        }
    }
}

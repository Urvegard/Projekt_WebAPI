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
        public async Task<ICollection<Attraction>>FilterAttractionByCategory(string Category)
        {
            var result = await _context.Attractions.Where(x => x.Category.Name == Category).ToListAsync();

            //var result = _context.Attractions.Include(b => b.Category).
            //    Include(b => b.City.Country).Include(b => b.City.Name).ToList();

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByCountry(string Country)
        {
            var result = await _context.Attractions.Where(x => x.City.Country.Name == Country).ToListAsync();

            return result;

        }
        public async Task<ICollection<Attraction>> FilterAttractionByName(string Name)
        {
            var result = await _context.Attractions.Where(x => x.Name == Name).ToListAsync();

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByDescription(string Description)
        {
            var result = await _context.Attractions.Where(x => x.Description == Description).ToListAsync();

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByCity(string City)
        {
            var result = await _context.Attractions.Where(x => x.City.Name == City).ToListAsync();

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionWhereNoComment()
        {
            var result = await _context.Attractions.Where(x => x.Comments.Count == 0).ToListAsync();

            return result;
        }
        public async Task<Attraction> FindAttractionByID(int Attractionid)
        {
            var result = await _context.Attractions.FindAsync(Attractionid);

            return result;
        }
    }
}

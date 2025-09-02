using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class CityRepo
    {
        private readonly TravelContext _context;

        public CityRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> AllCities()
        {
            var result = await _context.Cities.ToListAsync();

            return result;
        }

        public async Task<City> AddCity(City city)
        {
            await _context.Cities.AddAsync(city);

            var result = await _context.SaveChangesAsync();

            return city;
        }
    }
}

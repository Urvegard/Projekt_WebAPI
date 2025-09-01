using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class CountryRepo
    {
        private readonly TravelContext _context;

        public CountryRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> AllCountries()
        {
            var result = await _context.Countries.ToListAsync();

            return result;
        }

        public async Task<Country> AddCountry(Country country)
        {
            await _context.Countries.AddAsync(country);

            var result = await _context.SaveChangesAsync();

            return country;
        }
    }
}

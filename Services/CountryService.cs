using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class CountryService
    {
        private readonly CountryRepo _repo;

        public CountryService(CountryRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Country>> AllCountries()
        {
            var result = await _repo.AllCountries();

            return result;
        }

        public async Task<Country> AddCountry(Country country)
        {
            var result = await _repo.AddCountry(country);

            return result;
        }
    }
}

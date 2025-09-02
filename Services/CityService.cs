using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class CityService
    {
        private readonly CityRepo _repo;

        public CityService(CityRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<City>> AllCities()
        {
            var result = await _repo.AllCities();

            return result;
        }

        public async Task<City> AddCity(City city)
        {
            var result = await _repo.AddCity(city);

            return result;
        }
    }
}

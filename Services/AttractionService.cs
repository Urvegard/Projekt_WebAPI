using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class AttractionService
    {
        private readonly AttractionRepo _repo;

        public AttractionService(AttractionRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Attraction>> AllAttractions()
        {
            var result = await _repo.AllAttractions();

            return result;
        }

        public async Task<Attraction> AddAttraction(Attraction attraction)
        {
            var result = await _repo.AddAttraction(attraction);

            return result;
        }
    }
}

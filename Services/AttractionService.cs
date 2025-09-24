using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.DTOs;
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
        public async Task<ICollection<Attraction>> FilterAttractionByCategory(string Category)
        {
            var result = await _repo.FilterAttractionByCategory(Category);

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByCountry(string Country)
        {
            var result = await _repo.FilterAttractionByCountry(Country);

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByName(string Name)
        {
            var result = await _repo.FilterAttractionByName(Name);

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByDescription(string Description)
        {
            var result = await _repo.FilterAttractionByDescription(Description);

            return result;
        }
        public async Task<ICollection<Attraction>> FilterAttractionByCity(string City)
        {
            var result = await _repo.FilterAttractionByCity(City);

            return result;
        }
        public async Task<ICollection<AttractionsWhereCommentsNullDTO>> FilterAttractionWhereNoComment()
        {
            var result = await _repo.FilterAttractionWhereNoComment();

            return result;
        }
        public async Task<Attraction> FindAttractionByID(int Attractionid)
        {
            var result = await _repo.FindAttractionByID(Attractionid);

            return result;
        }
    }
}

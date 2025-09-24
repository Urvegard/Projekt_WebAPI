using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.DTOs;
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
        public async Task<ICollection<Attraction>> FilterAttractionByCategory(string Category)
        {
            var result = await _context.Attractions.Where(x => x.Category.Name == Category).ToListAsync();

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
        public async Task<ICollection<AttractionsWhereCommentsNullDTO>> FilterAttractionWhereNoComment()
        {
            var result = await _context.Attractions.Include(u => u.Comments).Where(i => !i.Comments.Any())
                .ToListAsync();
            var attracionNoComments = new List<AttractionsWhereCommentsNullDTO>();

            foreach (var attraction in result)
            {
                //Kommer att visa sevärdheter där kommentaren är null.

                var attractionNocomment = new AttractionsWhereCommentsNullDTO
                {
                    Name = attraction.Name,
                    Comments = attraction.Comments
                    .Select(c => new CommentsDTO
                    {
                        Text = c.Text,
                        AttractionName = c.Attraction?.Name
                    })
                    .ToList()
                };
                attracionNoComments.Add(attractionNocomment);
            }
            return attracionNoComments;
        }
        public async Task<Attraction> FindAttractionByID(int Attractionid)
        {
            var result = await _context.Attractions.FindAsync(Attractionid);

            return result;
        }
    }
}

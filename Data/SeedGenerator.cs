using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Models;
using System.Drawing.Text;

namespace Projekt_WebAPI.Data
{
    public class SeedGenerator
    {
        private readonly  TravelContext _context;
        private readonly Random _random;
        public SeedGenerator(TravelContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task Seeder()
        {
            if (await _context.Countries.AnyAsync())
            {

            }
        }
        public async Task ClearDatabase()
        {
            //Rensar DB:n

            await _context.Comments.ExecuteDeleteAsync();
            await _context.Users.ExecuteDeleteAsync();
            await _context.Attractions.ExecuteDeleteAsync();
            await _context.Cities.ExecuteDeleteAsync();
            await _context.Countries.ExecuteDeleteAsync();
            await _context.Categories.ExecuteDeleteAsync();

            //Sparar den nu rensade DB:n 
            await _context.SaveChangesAsync();
        }
        private async Task SeedCountries()
        {
            var countries = new List<Country> 
            {
                new Country { Name = "Sverige" },
                new Country { Name = "Norge" },
                new Country { Name = "Danmark" },
                new Country { Name = "Finland" }
            };

            // Detta ska vara efter varje metod, för att spara.
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();

        }
        private async Task SeedCategories()
        {
            // Skapa samma som Countries - ingen koppling mellan dem här.
        }
        private async Task SeedUsers()
        {
            // Skapa samma som Countries - ingen koppling mellan dem här.
        }
        private async Task SeedCities()
        {
            // Hämta alla Countries först, då city behöver ett country innan det läggs till i databasen. 
        }
        private async Task SeedAttractions()
        {

        }
        private async Task SeedComments()
        {
            //1. Hämta alla Attractions

            //2. Skapa slumpmässiga Comments

            //3. Koppla en slumpmässigt vald Attraction mot vår Comment
        }
    }
}

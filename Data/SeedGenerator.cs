using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Models;
using System;

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
            var categories = new[]
            {
                new Category { Name = "Restaurant" },
                new Category { Name = "Café" },
                new Category { Name = "Museum" },
                new Category { Name = "Architecture" },
                new Category { Name = "Nature" }
            };

            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }
        private async Task SeedUsers()
        {
            // Skapa samma som Countries - ingen koppling mellan dem här.
            var FirstNames = new[]
            {
                "Anna", "Erik", "Maria", "Lars", "Emma", "Johan", "Sara", "Magnus",
                "Lina", "David", "Astrid", "Nils", "Ingrid", "Oskar", "Maja", "Viktor",
                "Elsa", "Gustav", "Linnea", "Anton", "Elin", "Hugo", "Alice", "William"
            };

            var SurNames = new[]
            {
                "Andersson", "Johansson", "Karlsson", "Nilsson", "Eriksson", "Larsson",
                "Olsson", "Persson", "Svensson", "Gustafsson", "Pettersson", "Jonsson",
                "Jansson", "Hansson", "Bengtsson", "Jönsson", "Lindberg", "Jakobsson"
            };

            // Skapa ny lista över seedade användare där minst 50 skapas upp emot 75 totalt
            var users = new List<User>();
            var userCount = 50;
            //var userCount = _random.Next(50, 75);

            // For-loop för att iterera och skapa antalet användare
            for (int i = 0; i < userCount; i++)
            {
                users.Add(new User
                {
                    Name = FirstNames[_random.Next(FirstNames.Length)],
                    SurName = SurNames[_random.Next(SurNames.Length)]
                });
            }
            // Detta ska vara efter varje metod, för att spara.
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        private async Task SeedCities()
        {
            // Hämta alla Countries först, då city behöver ett country innan det läggs till i databasen.

            // Hämtar alla länder som finns inuti databasen
            var countries = await _context.Countries.ToListAsync();

            // Sverige
            var swedishCities = new[]
            {
                "Stockholm", "Göteborg", "Malmö", "Uppsala", "Västerås", "Örebro",
                "Linköping", "Helsingborg", "Jönköping", "Norrköping", "Lund", "Umeå",
                "Gävle", "Borås", "Eskilstuna", "Södertälje", "Karlstad", "Täby",
                "Växjö", "Halmstad", "Luleå", "Trollhättan", "Kalmar", "Skövde", "Falun"
            };

            // Norge
            var norwegianCities = new[]
            {
                "Oslo", "Bergen", "Trondheim", "Stavanger", "Drammen", "Fredrikstad",
                "Kristiansand", "Sandnes", "Tromsø", "Sarpsborg", "Skien", "Ålesund",
                "Haugesund", "Sandefjord", "Bodø", "Arendal", "Hamar", "Halden",
                "Larvik", "Moss", "Harstad", "Molde", "Gjøvik", "Lillehammer", "Alta"
            };

            // Danmark
            var danishCities = new[]
            {
                "København", "Aarhus", "Odense", "Aalborg", "Esbjerg", "Randers",
                "Kolding", "Horsens", "Vejle", "Roskilde", "Hørsholm", "Helsingør",
                "Silkeborg", "Næstved", "Fredericia", "Ballerup", "Herning", "Viborg",
                "Køge", "Holstebro", "Slagelse", "Taastrup", "Sønderborg", "Svendborg", "Hillerød"
            };

            // Finland
            var finnishCities = new[]
            {
                "Helsinki", "Espoo", "Tampere", "Vantaa", "Oulu", "Turku",
                "Jyväskylä", "Lahti", "Kuopio", "Pori", "Kouvola", "Joensuu",
                "Lappeenranta", "Hämeenlinna", "Vaasa", "Seinäjoki", "Rovaniemi",
                "Mikkeli", "Kotka", "Salo", "Porvoo", "Kokkola", "Kajaani", "Savonlinna", "Kemi"
            };

            // Vi vill ha minst 100 städer totalt
            var totalCityCount = 100;
            var cities = new List<City>();

            for (int i = 0; i < totalCityCount; i++)
            {
                // Slumpa land först
                var countryId = _random.Next(1, 5); // 1–4 (1=Sverige, 2=Norge, 3=Danmark, 4=Finland)

                string cityName = countryId switch
                {
                    1 => swedishCities[_random.Next(swedishCities.Length)],
                    2 => norwegianCities[_random.Next(norwegianCities.Length)],
                    3 => danishCities[_random.Next(danishCities.Length)],
                    4 => finnishCities[_random.Next(finnishCities.Length)],
                    _ => "Unknown"
                };

                // Lägger till skapade orten/staden
                cities.Add(new City
                {
                    Name = cityName,
                    CountryId = countryId
                });
                // Letar efter specifikt land och dess ID

                //var sverige = countries.First(c => c.Name == "Sverige");
                //cities.Add(new City { Name = "Stockholm", CountryId = sverige.Id });

                //var norge = countries.First(c => c.Name == "Norge");
                //cities.Add(new City { Name = "Oslo", CountryId = norge.Id });

                //var danmark = countries.First(c => c.Name == "Danmark");
                //cities.Add(new City { Name = "Köpenhamn", CountryId = danmark.Id });

                //var finland = countries.First(c => c.Name == "Finland");
                //cities.Add(new City { Name = "Helsingfors", CountryId = finland.Id });

                // TODO: Add more cities for different countries
                // 
                await _context.Cities.AddRangeAsync(cities);
                await _context.SaveChangesAsync();
            }
        }
        private async Task SeedAttractions()
        {
            // Hämta CityId och CategoryId från databasen
            var cityIds = _context.Cities.Select(c => c.Id).ToList();
            var categoryIds = _context.Categories.Select(c => c.Id).ToList();

            var attractions = new List<Attraction>();

            // Minst 1000 sevärdheter
            var totalAttractions = 1000;

            // For-loop för att generera 1000 st sevärdheter med random namn etc
            for (int i = 0; i < totalAttractions; i++)
            {
                var cityId = cityIds[_random.Next(cityIds.Count)];
                var categoryId = categoryIds[_random.Next(categoryIds.Count)];

                var titles = new[]
                {
                    "Grand Plaza", "Old Town Hall", "City Park", "National Museum",
                    "Modern Art Gallery", "Skyview Tower", "Botanical Garden",
                    "Royal Theater", "Historic Cathedral", "Central Market"
                };

                var descriptions = new[]
                {
                    "A popular place with rich history.",
                    "Known for its beautiful architecture.",
                    "A must-see attraction in the area.",
                    "Perfect for a weekend visit.",
                    "One of the most visited places in the city."
                };

                // Lägger till alla seedade/skapade sevärdheter i listan
                attractions.Add(new Attraction
                {
                    Name = titles[_random.Next(titles.Length)] + " " + (i + 1),
                    Description = descriptions[_random.Next(descriptions.Length)],
                    CityId = cityId,
                    CategoryId = categoryId
                });
            }

            // Lägg till i databasen och spara
            await _context.Attractions.AddRangeAsync(attractions);
            await _context.SaveChangesAsync();
        }
        private async Task SeedComments()
        {
            //1. Hämta alla Attractions

            //2. Skapa slumpmässiga Comments

            //3. Koppla en slumpmässigt vald Attraction mot vår Comment
        }
    }
}

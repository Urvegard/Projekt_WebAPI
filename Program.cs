
using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Repository;
using Projekt_WebAPI.Services;

namespace Projekt_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TravelContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

            //Services
            builder.Services.AddScoped<UserService>();

            //Repositories
            builder.Services.AddScoped<UserRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

// 1. Skapa Modeller (klasser)

// 2. Skapa Controller -> Vid skapande välj "API empty" -> [HttpGet]

// 3. Lägg till DbSet i TravelContext ex: public virtual DbSet<City> Cities { get; set; }

// 4. add-migration (sök efter package manager console)

// 5. update-database (sök efter package manager console)


// 1. Skapa en Service och en Repo för alla entiteter. Kopiera User! Glöm inte Program.cs(builder).


// Controllern = Kommunicerar mot användaren 
// Service = bearbetar data "Hjärnan bakom allt"
// Repository = kommunicerar mot databasen

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

// 2. Skapa Controller -> Vid skapande v�lj "API empty" -> [HttpGet]

// 3. L�gg till DbSet i TravelContext ex: public virtual DbSet<City> Cities { get; set; }

// 4. add-migration (s�k efter package manager console)

// 5. update-database (s�k efter package manager console)


// 1. Skapa en Service och en Repo f�r alla entiteter. Kopiera User! Gl�m inte Program.cs(builder).


// Controllern = Kommunicerar mot anv�ndaren 
// Service = bearbetar data "Hj�rnan bakom allt"
// Repository = kommunicerar mot databasen
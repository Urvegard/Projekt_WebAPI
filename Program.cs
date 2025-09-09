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
            builder.Services.AddScoped<CountryService>();
            builder.Services.AddScoped<CommentService>();
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<AttractionService>();


            //Repositories
            builder.Services.AddScoped<UserRepo>();
            builder.Services.AddScoped<CountryRepo>();
            builder.Services.AddScoped<CommentRepo>();
            builder.Services.AddScoped<CityRepo>();
            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<AttractionRepo>();

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


// Skapa SeedGenerator inuti "Data - folder".

// Vi behöver bara USER(klar) - ATTRACTION(klar) - COMMENTS(klar) + SEED.
using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Repository;
using Projekt_WebAPI.Services;

namespace Projekt_WebAPI
{
    public class Program
    {
        //public static void Main(string[] args)
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TravelContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
            
            // Add services to the container.
            builder.Services.AddScoped<SeedGenerator>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            // ---- SEED DATA VID START ----
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedGenerator>();
                await seeder.Seeder();  // <--- kör seedingmetoder
            }

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

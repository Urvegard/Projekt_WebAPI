using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Data
{
    public class TravelContext:DbContext
    {
        public TravelContext()
        {
            
        }

        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
            
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Attraction> Attractions { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Anropar basklassens logik
            base.OnModelCreating(modelBuilder);

            // Index exempel (snabbare sökning)
            //Skapar ett index i databasen på kolumnen Name i tabellen City
            modelBuilder.Entity<City>()
                .HasIndex(c => c.Name);

            //Skapar ett index i databasen på kolumnen Name i tabellen Attraction
            modelBuilder.Entity<Attraction>()
                .HasIndex(a => a.Name);

            // Seeding kan också läggas här senare
        }

    }
}

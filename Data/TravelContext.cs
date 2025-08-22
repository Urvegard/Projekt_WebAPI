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

    }
}

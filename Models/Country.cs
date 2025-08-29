using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        // Relation: Country har många Cities
        public ICollection<City> Cities { get; set; }
    }
}

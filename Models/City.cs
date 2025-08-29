using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class City
    {
        [Key] //Primary Key
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Relation: City har många Attractions
        public ICollection<Attraction> Attractions { get; set; }
    }
}

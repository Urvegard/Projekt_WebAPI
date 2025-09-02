using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public ICollection<Attraction> Attractions { get; set; }
    }
}

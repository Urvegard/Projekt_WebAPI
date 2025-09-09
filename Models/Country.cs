using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projekt_WebAPI.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        // Relation: Country har många Cities
        // Foreign Key
        [JsonIgnore]
        public ICollection<City> Cities { get; set; }
    }
}

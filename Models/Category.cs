using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projekt_WebAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        // Relation: Category har många Attractions
        // Foreign Key
        [JsonIgnore]
        public ICollection<Attraction> Attractions { get; set; }
    }
}

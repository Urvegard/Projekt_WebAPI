using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        // Relation: Category har många Attractions
        public ICollection<Attraction> Attractions { get; set; }
    }
}

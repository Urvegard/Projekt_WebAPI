using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class Attraction
    {
        [Key] //Primary Key
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        // Foreign Keys
        public int CityId { get; set; }
        public City City { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Relation: Attraction har många Comments
        public ICollection<Comment> Comments { get; set; }
    }
}

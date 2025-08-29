using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        // Relation: User har många Comments
        public ICollection<Comment> Comments { get; set; }
    }
}

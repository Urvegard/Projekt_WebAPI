using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projekt_WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        // Foreign Key
        //public int CommentId { get; set; }
        //public Comment Comments { get; set; }

        // Relation: User kan ha många Comments
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        // Foreign Keys - En user kan SKRIVA många "comments" och en attraction kan HA många "comments.
        public int UserId { get; set; }
        public User Users { get; set; }

        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
    }
}

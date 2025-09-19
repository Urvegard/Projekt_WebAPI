using Projekt_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.DTOs
{
    public class UserWithCommentsDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string SurName { get; set; }

        public List<CommentsDTO> Comments { get; set; }
    }
}

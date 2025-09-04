using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.DTOs
{
    // För att skapa nya "Users" (Post Requests)
    public class CreateUserDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string SurName { get; set; }

    }
}

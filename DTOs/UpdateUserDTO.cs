using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string SurName { get; set; }
    }
}

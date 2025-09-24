using Projekt_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.DTOs
{
    public class AttractionsWhereCommentsNullDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CommentsDTO> Comments { get; set; }

    }
}

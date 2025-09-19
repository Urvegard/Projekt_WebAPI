using Projekt_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.DTOs
{
    public class CommentsDTO 
    {
        public string AttractionName { get; set; }
        public string Text { get; set; }
    }
}

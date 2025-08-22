using System.ComponentModel.DataAnnotations;

namespace Projekt_WebAPI.Models
{
    public class City
    {
        [Key] //Primary Key
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dotnet_seed_database_boilerplate.Models
{
    public class Beer
    {
        [Key]
        public int Key { get; set; }
        public string Name { get; set; }        
        public string Type { get; set; }
        public int Ounces { get; set; }
    }
}
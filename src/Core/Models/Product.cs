using System.ComponentModel.DataAnnotations;

namespace Hllch.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        // Add other properties as needed
    }
}

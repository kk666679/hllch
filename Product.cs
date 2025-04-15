using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class Product
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Add other necessary properties here
    }
}

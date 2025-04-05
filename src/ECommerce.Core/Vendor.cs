using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Core.Entities
{
    public class Vendor
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(100)]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string Description { get; private set; }

        [Required]
        public string UserId { get; private set; }

        public DateTime JoinDate { get; private set; } = DateTime.UtcNow;

        public bool IsApproved { get; private set; } = false;

        public ICollection<Product> Products { get; private set; } = new HashSet<Product>();

        public Vendor(string name, string userId, string description = "")
        {
            Name = name;
            UserId = userId;
            Description = description;
        }

        public void Approve() => IsApproved = true;
    }
}

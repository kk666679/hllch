namespace ECommerce.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}

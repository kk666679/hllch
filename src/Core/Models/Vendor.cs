using System.Collections.Generic;

namespace Hllch.Core.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

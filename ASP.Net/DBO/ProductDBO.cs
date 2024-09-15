using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DBO
{
    public class ProductDBO
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int? stock { get; set; }
    }
}

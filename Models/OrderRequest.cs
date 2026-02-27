
namespace MyApp
{
    public class OrderRequest
    {
        public required string ProductId { get; set; }
        public int Quantity { get; set; }
        public required string Country { get; set; }
        // "MK", "DE", "FR", "USA"
    }
}
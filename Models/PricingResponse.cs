
namespace MyApp
{
    public class PricingResponse
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public required string Country { get; set; }
        // // "MK", "DE", "FR", "USA"
        public decimal Subtotal { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public required string TaxCountry { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FinalPrice { get; set; } 
    }
}
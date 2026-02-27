using System.IO;
using System.Text.Json;

namespace MyApp
{
    public class PricingService
    {

        public PricingResponse CalculatePrice(OrderRequest request)
        {
            Console.WriteLine($"Input: productId: {request.ProductId}, quantity: {request.Quantity}, country: {request.Country}");
            var product = GetProduct(request.ProductId);
            decimal subtotal = request.Quantity * product.Price;
            // Calculate discount
            decimal discountPct = CalculateDiscount(request.Quantity, subtotal);
            decimal discountAmount = subtotal * discountPct;
            // Calculate tax
            decimal taxRate = GetTaxRate(request.Country);
            decimal taxAmount = (subtotal - discountAmount) * taxRate;
            decimal finalPrice = subtotal - discountAmount + taxAmount;
            
            return BuildResponse(product, request, subtotal,
            discountPct, discountAmount,
            taxRate, taxAmount, finalPrice);
        }
        private decimal CalculateDiscount(int quantity, decimal subtotal)
        {
            decimal discount = 0;
            if (subtotal >= 500)
            {
                if (quantity >= 10)
                    // Apply 5% discount if quantity is 10 or more
                    discount = 0.05m;
                if (quantity > 50)
                    discount = 0.10m;
                if (quantity >= 100)
                    discount = 0.15m;
            }
            return discount;
        }
        private decimal GetTaxRate(string country)
        {
            return country switch
            {
            "MK" => 0.18m,
            "DE" => 0.20m,
            "FR" => 0.20m,
            "USA" => 0.10m,
            _ => 0.20m
            };
        }
        private Product GetProduct(string productId)
        {
            // Load from products.json file
            // YOU NEED TO IMPLEMENT THIS
            string json = File.ReadAllText("products.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var products = JsonSerializer.Deserialize<ProductResponse>(json, options);
            
            if (products == null)
            {
                throw new InvalidOperationException("Failed to deserialize products from products.json");
            }

            var product = products.Products.FirstOrDefault(p => p.Id == productId);
            
            if (product == null)
            {
                throw new ArgumentException($"Product with ID '{productId}' not found.");
            }
            
            return product;
        }

        private PricingResponse BuildResponse(Product product, OrderRequest request, decimal subtotal,
            decimal discountPct, decimal discountAmount,
            decimal taxRate, decimal taxAmount, decimal finalPrice)
        {
            return new PricingResponse
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = request.Quantity,
                Country = request.Country,
                Subtotal = subtotal,
                DiscountPercentage = discountPct,
                DiscountAmount = discountAmount,
                TaxRate = taxRate,
                TaxAmount = taxAmount,
                TaxCountry = request.Country,
                FinalPrice = finalPrice
            };
        }
    }
}
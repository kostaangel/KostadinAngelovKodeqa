using System;

namespace MyApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Console.WriteLine("Hello World again!");    
      var service = new PricingService();

      Console.WriteLine("Your calculated finalPrice: " + service.CalculatePrice(new OrderRequest
      {
        ProductId = "PROD-001",
        Quantity = 55,
        Country = "MK"
      }).FinalPrice); 
      
      Console.WriteLine("Your calculated finalPrice: " + service.CalculatePrice(new OrderRequest
      {
        ProductId = "PROD-001",
        Quantity = 100,
        Country = "DE"
      }).FinalPrice); 

      Console.WriteLine("Your calculated finalPrice: " + service.CalculatePrice(new OrderRequest
      {
        ProductId = "PROD-001",
        Quantity = 25,
        Country = "USA"
      }).FinalPrice);    
    }
  }
}
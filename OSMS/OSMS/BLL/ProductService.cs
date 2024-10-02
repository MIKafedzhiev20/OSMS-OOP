using DAL;

namespace BLL
{
    public class ProductService
    {
        // Display product details
        public void DisplayProductDetails(Product product)
        {
            product.DisplayProductDetails();
        }

        // Check product stock
        public bool IsProductInStock(Product product, int quantity)
        {
            return product.Stock >= quantity;
        }

        // Event handler for out-of-stock products
        public void SubscribeToOutOfStockEvent(Product product)
        {
            product.OutOfStockEvent += message => Console.WriteLine($"{message}");
        }
    }
}

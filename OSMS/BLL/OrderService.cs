using OSMS.DAL;

namespace OSMS.BLL
{
    public class OrderService
    {
        private IOrder _order;

        // Create an order for a physical product
        public bool CreatePhysicalProductOrder(ICustomer customer, PhysicalProduct product, int quantity)
        {
            _order = new PhysicalProductOrder();
            return _order.CreateOrder(customer, product, quantity);
        }

        // Apply a discount to the order
        public void ApplyDiscount(IDiscount discount)
        {
            _order.ApplyDiscount(discount);
        }

        // Complete the order and process the payment
        public void CompleteOrder(IPayment payment)
        {
            _order.CompleteOrder();
            payment.ProcessPayment(GetTotalAmount());
        }

        // Mock method to retrieve total amount (this would normally be tracked inside the order)
        private decimal GetTotalAmount()
        {
            // In reality, you might have this amount stored in the order itself
            return 1000.00m; // Example amount
        }
    }
}

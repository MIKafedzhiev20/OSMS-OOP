using DAL;

namespace DAL
{
    public interface IOrder
    {
        bool CreateOrder(ICustomer customer, Product product, int quantity);
        void ApplyDiscount(IDiscount discount);
        void CompleteOrder();
    }

    public class PhysicalProductOrder : IOrder
    {
        private ICustomer _customer;
        private Product _product;
        private int _quantity;
        private decimal _totalAmount;

        public bool CreateOrder(ICustomer customer, Product product, int quantity)
        {
            if (product.DeductStock(quantity))
            {
                _customer = customer;
                _product = product;
                _quantity = quantity;
                _totalAmount = product.Price * quantity;
                return true;
            }
            return false;
        }

        public void ApplyDiscount(IDiscount discount)
        {
            _totalAmount = discount.ApplyDiscount(_totalAmount);
        }
        public decimal GetTotalAmount()
        {
            return _totalAmount;
        }

        public void CompleteOrder()
        {
            Console.WriteLine($"{_customer.FirstName} {_customer.LastName} ordered {_quantity} {_product.Name}(s). Total amount: {_totalAmount}");
        }
    }
}

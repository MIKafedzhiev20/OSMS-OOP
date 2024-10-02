namespace OSMS.DAL
{
    // Base Product Class
    public abstract class Product
    {
        public string Name { get; }
        public decimal Price { get; protected set; }
        public int Stock { get; protected set; }

        // Event for Out of Stock
        public event Action<string> OutOfStockEvent;

        protected Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool DeductStock(int quantity)
        {
            if (quantity > Stock)
            {
                return false;
            }
            Stock -= quantity;
            if (Stock == 0)
            {
                OutOfStockEvent?.Invoke($"{Name} is out of stock.");
            }
            return true;
        }

        public abstract void DisplayProductDetails();
    }

    // Concrete PhysicalProduct Class
    public class PhysicalProduct : Product
    {
        public PhysicalProduct(string name, decimal price, int stock) : base(name, price, stock) { }

        public override void DisplayProductDetails()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price:C}, Stock: {Stock} (Physical)");
        }
    }

    // Concrete DigitalProduct Class
    public class DigitalProduct : Product
    {
        public DigitalProduct(string name, decimal price) : base(name, price, int.MaxValue) { }

        public override void DisplayProductDetails()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price:C} (Digital)");
        }
    }
}

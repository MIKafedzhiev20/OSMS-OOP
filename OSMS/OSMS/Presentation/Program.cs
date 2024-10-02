using System;
using BLL;
using DAL;

public class Program
{
    public static void Main()
    {
        // Initialize services
        CustomerService customerService = new CustomerService();
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();

        // Create a customer
        ICustomer customer = new Customer("John", "Doe");

        // Display customer information
        customerService.DisplayCustomerInfo(customer);

        // Create products
        PhysicalProduct laptop = new PhysicalProduct("Laptop", 1000.00m, 5);
        PhysicalProduct smartphone = new PhysicalProduct("Smartphone", 700.00m, 2);

        // Subscribe to the out-of-stock event
        productService.SubscribeToOutOfStockEvent(laptop);
        productService.SubscribeToOutOfStockEvent(smartphone);

        // Create and place orders using OrderService
        Console.WriteLine("\nPlacing first laptop order...");
        if (orderService.CreatePhysicalProductOrder(customer, laptop, 3))
        {
            // Apply a 10% discount to the laptop order
            orderService.ApplyDiscount(new PercentageDiscount(10));

            // Process the payment and complete the order
            orderService.CompleteOrder(new CreditCardPayment());
        }

        Console.WriteLine("\nPlacing smartphone order...");
        if (orderService.CreatePhysicalProductOrder(customer, smartphone, 2))
        {
            // Apply a $50 fixed discount to the smartphone order
            orderService.ApplyDiscount(new FixedDiscount(50));

            // Process the payment and complete the order
            orderService.CompleteOrder(new PayPalPayment());
        }

        // Attempt to create an order with insufficient stock
        Console.WriteLine("\nAttempting second laptop order with insufficient stock...");
        if (!orderService.CreatePhysicalProductOrder(customer, laptop, 3))
        {
            Console.WriteLine("Failed to create second laptop order due to insufficient stock.");
        }
    }
}

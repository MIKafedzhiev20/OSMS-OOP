using DAL;

namespace BLL
{
    public class CustomerService
    {
        // Display customer information
        public void DisplayCustomerInfo(ICustomer customer)
        {
            customer.DisplayCustomerInfo();
        }

        // Additional customer-related logic can be added here
    }
}

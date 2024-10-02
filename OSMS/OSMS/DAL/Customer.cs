namespace DAL
{
    public class Customer : ICustomer
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer: {FirstName} {LastName}");
        }
    }

    public interface ICustomer
    {
        string FirstName { get; }
        string LastName { get; }
        void DisplayCustomerInfo();
    }
}

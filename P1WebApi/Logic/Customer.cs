namespace Logic
{
    public class Customer
    {
        public int CustomerId { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public Customer() { }

        public Customer(int customerId, string firstName, string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;

        }
    }
}
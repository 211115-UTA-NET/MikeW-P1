using P1WebApi.Models;

namespace P1WebApi.Services
{
    public class CustomerService
    {
        static List<Customer> Name { get;  }
        static int nextId = 0;
        static CustomerService()
        {
            Name = new List<Customer>
            {
                new Customer {CustId = 1, FirstName = "Mike", LastName = "Wawrzyniak"},
                new Customer {CustId = 2, FirstName = "Bobby", LastName= "Hill"}
            };
        }

        public static List<Customer> GetAll() => Name;
        public static Customer? Get(int id ) => Name.FirstOrDefault(p => p.CustId == id);
        public static void Add(Customer customer)
        {
            customer.CustId = nextId++;
            Name.Add(customer);
        }

        public static void Delete(int id)
        {
            var customer = Get(id);
            if(customer is null)
                return;
            Name.Remove(customer);
        }

        public static void Update(Customer customer)
        {
            var index = Name.FindIndex(p => p.CustId == customer.CustId);
            if (index == -1)
                return;

            Name[index] = customer;
        }
    }
}

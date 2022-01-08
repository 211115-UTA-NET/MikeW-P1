using Logic;

namespace P1WebApi.DataStorage
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(int custId);

         public static void AddNewCustomer(string firstName, string lastName)
        {

        }
    }
}
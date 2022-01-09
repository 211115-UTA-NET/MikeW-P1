using Logic;
using Microsoft.AspNetCore.Mvc;

namespace DataStorage
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync(string FirstName);
       // Task<IEnumerable<Store>> GetInventoryListAsync();

         public static void AddNewCustomer(string firstName, string lastName)
        {

        }
    }
}
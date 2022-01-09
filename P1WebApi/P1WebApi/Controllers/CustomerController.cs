using Logic;
using DataStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace P1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;
        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }
        //Get All Customers 
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Customer>>> GetAlCustomersAsync(string FirstName)
        {

            IEnumerable<Customer> customer;
            try
            {
                customer = await _repository.GetAllCustomersAsync(FirstName);
            }
            catch (SqlException )
            {
                return StatusCode(500);
            }
            return customer.ToList();
        }
      
    }
}

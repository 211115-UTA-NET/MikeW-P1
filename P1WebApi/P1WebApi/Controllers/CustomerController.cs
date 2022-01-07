using P1WebApi.Models;
using P1WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.SqlClient;
using Nest;

namespace P1WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;
        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }
        //Get All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllAsync([FromQuery, Required] int custId)
        {
            IEnumerable<Customer> customer;
            try
            {
                customer = (IEnumerable<Customer>)await _repository.GetAllAsync(custId); 
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            return customer.ToList();
        }



        //Get by CustId
        [HttpGet("{CustId}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = CustomerService.Get(id);
            if(customer == null)
                return NotFound();

            return customer;
        }
        //POST
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            CustomerService.Add(customer);
            return CreatedAtAction(nameof(Create), new {id = customer.CustId}, customer);
        }

        //PUT
        [HttpPut]
        public IActionResult Update(int id, Customer customer)
        {
            if(id != customer.CustId)
                return BadRequest();

            var existingCustomers = CustomerService.Get(id);
            if (existingCustomers == null)
                return NotFound();

            CustomerService.Update(customer);

            return NoContent();
        }
        
        //DELETE
        [HttpDelete("CustId")]
        public IActionResult Delete(int id)
        {
            var customer = CustomerService.Get(id);

            if (customer == null)
                return NotFound();

            CustomerService.Delete(id);

            return NoContent();
        }
    }
}

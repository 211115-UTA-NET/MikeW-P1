using P1WebApi.Models;
using P1WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace P1WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }
        // GET all action
        [HttpGet]
        public ActionResult<List<Products>> GetAll() =>
            ProductsService.GetAll();

        // GET by Id action - maybe change to Get by Name
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            var product = ProductsService.Get(id);

            if (product == null)
                return NotFound();

            return product;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Products product)
        {
            //NEED TO CHANGE TO ORDER - could this be used to add Products to a cart?? 
            //saves a product and returns a result
            ProductsService.Add(product);
            return CreatedAtAction(nameof(Create), new {id = product.ProductId}, product);
        }

        // PUT action - CHANGE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Products product)
        {
            //this code will update the Product and return a result
            if(id != product.ProductId)
                return BadRequest();    
            
            var existingProducts = ProductsService.Get(id);
            if (existingProducts == null)
                return NotFound();

            ProductsService.Update(product);

            return NoContent();
        }
        // DELETE action - CHANGE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //will delete a product and return  result
            var product = ProductsService.Get(id);

            if (product == null)
                return NotFound();

            ProductsService.Delete(id);

            return NoContent();
        }
    }
}

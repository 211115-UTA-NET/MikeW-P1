using Logic;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Nest;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using DataStorage;

namespace P1WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IRepository _repository;
        public StoreController(IRepository repository)
        {
            _repository = repository;
        }
        // GET all action
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Store>>> GetInventoryListAsync()
        //{
        //    IEnumerable<Store> stores;
        //    try
        //    {
        //        stores = await _repository.GetInventoryListAsync();
        //    }
        //    catch (SqlException ex)
        //    {
        //        return StatusCode(500);
        //    }
        //    return stores.ToList();
        //}

    }
}

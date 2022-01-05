using P1ConsoleApp;
using P1WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    internal class SqlRepository : IRepository
    {
        public Task<IEnumerable<Customer>> GetAllAsync(string custId)
        {
            throw new NotImplementedException();
        }
    }
}

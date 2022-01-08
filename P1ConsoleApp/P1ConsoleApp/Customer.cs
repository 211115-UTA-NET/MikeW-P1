using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace P1ConsoleApp
{
    public class Customer
    {
        public int CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
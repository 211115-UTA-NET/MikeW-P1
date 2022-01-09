using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P1ConsoleApp
{
    public class Order
    {
        internal string Name { get; set; }
        internal decimal price { get; set; }
        internal int quantity { get; set; }

        public Order()
        {
            Name = "nothing yet";
            price = 0;
        }

        public Order(string a, int b, decimal c)
        {
            Name = a;
            quantity = b;
            price = c;

        }
        public override string ToString()
        {
            return "Name: " + Name + " the price is: $" + price;
        }
    }
}

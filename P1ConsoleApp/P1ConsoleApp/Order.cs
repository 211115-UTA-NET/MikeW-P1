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

        public Order(string a, int b, decimal c )
        {
            Name = a;
            quantity = b;
            price = c;
            
        }
        public override string ToString()
        {
            return "Name: " + Name + " the price is: $" + price;
        }
            
        public static void AddNewOrderMilwaukee()
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");
            
            string storeLocation = "Milwaukee, WI ";
            int orderId = 1;
            DateTime orderDate = DateTime.Now;
            string firstName = " ";
            string lastName = " ";
            

        //    using SqlConnection connection = new(connectionString);
        //    connection.Open();

        //    using SqlCommand command = new($"INSERT INTO Orders (StoreLocation, OrderId, OrderDate, FirstName, LastName) Values(@storeLocation, @orderId, @orderDate, @firstName, @lastName);", connection);
        //    command.Parameters.AddWithValue("@storeLocation", storeLocation);
        //    command.Parameters.AddWithValue("@orderId", orderId);
        //    command.Parameters.AddWithValue("@orderDate", orderDate);
        //    command.Parameters.AddWithValue("@firstName", firstName);
        //    command.Parameters.AddWithValue("@lastName", lastName);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}
        //public static void AddNewOrderMadison()
        //{
        //    string storeLocation = "Madison, WI ";
        //    int orderId = 1;
        //    DateTime orderDate = DateTime.Now;
        //    string firstName = " ";
        //    string lastName = " ";

        //    string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");

        //    using SqlConnection connection = new(connectionString);
        //    connection.Open();

        //    using SqlCommand command = new($"INSERT INTO Orders (StoreLocation, OrderId, OrderDate, FirstName, LastName) Values(@storeLocation, @orderId, @orderDate, @firstName, @lastName);", connection);
        //    command.Parameters.AddWithValue("@storeLocation", storeLocation);
        //    command.Parameters.AddWithValue("@orderId", orderId);
        //    command.Parameters.AddWithValue("@orderDate", orderDate);
        //    command.Parameters.AddWithValue("@firstName", firstName);
        //    command.Parameters.AddWithValue("@lastName", lastName);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        }


   }
}

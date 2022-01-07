using P1ConsoleApp;
using P1WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class SqlRepository : IRepository
    {
        private readonly string _connectionString;
        
        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        //Gets all customers from DB
        public async Task<IEnumerable<Customer>> GetAllAsync(int custId)
        {
            List<Customer> result = new();

            SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand cmd = new($"SELECT * FROM Customers", connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            connection.Close();
            
            return result;
        }
        //adding nw customer to database
        public static void AddNewCustomer(string firstName, string lastName)
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new($"INSERT INTO Customers (FirstName, LastName) Values(@firstName, @lastName);", connection);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

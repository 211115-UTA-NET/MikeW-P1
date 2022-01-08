using P1WebApi.Controllers;
using System.Data.SqlClient;

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
        internal static void StoreInventoryMilwaukee()
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");

            //shows store inventory
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string commandText = "SELECT * FROM Store Where location = 'Milwaukee, WI'";

            using SqlCommand command = new(commandText, connection);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Location = reader.GetString(0);
                string ItemName = reader.GetString(1);
                int Quantity = reader.GetInt32(2);
                decimal Price = reader.GetDecimal(3);

                Console.WriteLine($"In stock in {Location} are {ItemName}, there are {Quantity}, each one costs ${Price}");
            }
        }
        internal static void StoreInventoryMadison()
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");

            //shows store inventory
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string commandText = "SELECT * FROM Store Where location = 'Madison, WI'";

            using SqlCommand command = new(commandText, connection);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Location = reader.GetString(0);
                string ItemName = reader.GetString(1);
                int Quantity = reader.GetInt32(2);
                decimal Price = reader.GetDecimal(3);

                Console.WriteLine($"In stock in {Location} are {ItemName}, there are {Quantity}, each one costs ${Price}");
            }
        }
    }
}

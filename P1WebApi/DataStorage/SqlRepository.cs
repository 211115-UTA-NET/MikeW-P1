using System.Data.SqlClient;
using Logic;


namespace DataStorage
{
    public class SqlRepository : IRepository
    {
        private readonly string _connectionString;
        //string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");
        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        //Gets all customers from DB
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(string FirstName)
        {
            List<Customer> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand cmd = new(@"SELECT FirstName, LastName FROM Customers", connection);
            //cmd.Parameters.AddWithValue(@"FirstName", FirstName);
            using SqlDataReader reader = cmd.ExecuteReader();
            //while(await reader.ReadAsync())
            //{

            //}
           await connection.CloseAsync();

            return result;
        }
       // adding nw customer to database
        public static void AddNewCustomer(string firstName, string lastName)
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string commandText = @"INSERT INTO Customers (FirstName, LastName) Values(@firstName, @lastName);";

            using SqlCommand command = new(commandText, connection);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            command.ExecuteNonQuery();
            connection.Close();
        }
      
        public static void StoreInventoryMadison()
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
        public static void AddNewOrderMilwaukee()
        {
            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");

            string storeLocation = "Milwaukee, WI ";
            int orderId = 1;
            DateTime orderDate = DateTime.Now;
            string firstName = " ";
            string lastName = " ";


            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"INSERT INTO Orders (StoreLocation, OrderId, OrderDate, FirstName, LastName) Values(@storeLocation, @orderId, @orderDate, @firstName, @lastName);", connection);
            command.Parameters.AddWithValue("@storeLocation", storeLocation);
            command.Parameters.AddWithValue("@orderId", orderId);
            command.Parameters.AddWithValue("@orderDate", orderDate);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void AddNewOrderMadison()
        {
            string storeLocation = "Madison, WI ";
            int orderId = 1;
            DateTime orderDate = DateTime.Now;
            string firstName = " ";
            string lastName = " ";

            string connectionString = File.ReadAllText("C:/Users/mjwaw/Revature/TextFile1.txt");

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"INSERT INTO Orders (StoreLocation, OrderId, OrderDate, FirstName, LastName) Values(@storeLocation, @orderId, @orderDate, @firstName, @lastName);", connection);
            command.Parameters.AddWithValue("@storeLocation", storeLocation);
            command.Parameters.AddWithValue("@orderId", orderId);
            command.Parameters.AddWithValue("@orderDate", orderDate);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.ExecuteNonQuery();
            connection.Close();
        }
            //shows store inventory
        //async Task<IEnumerable<Store>> IRepository.GetInventoryListAsync()
        //{
        //    List<Store> result = new();

        //    using SqlConnection connection = new(connectionString);
        //    await connection.OpenAsync();

        //    string commandText = @"SELECT * FROM Store Where location = 'Milwaukee, WI'";

        //    using SqlCommand command = new(commandText, connection);

        //    using SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string Location = reader.GetString(0);
        //        string ItemName = reader.GetString(1);
        //        int Quantity = reader.GetInt32(2);
        //        decimal Price = reader.GetDecimal(3);

        //        Console.WriteLine($"In stock in {Location} are {ItemName}, there are {Quantity}, each one costs ${Price}");
        //    }
        //    connection.Close();
        //    return result;
        //}

       
    }
}

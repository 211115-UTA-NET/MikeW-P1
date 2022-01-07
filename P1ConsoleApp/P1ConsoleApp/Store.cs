using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace P1ConsoleApp
{
	public class Store
	{
		internal List<Order> InventoryList { get; set; }
		internal List<Order> ShoppingList { get; set; }
		public Store()
		{
			InventoryList = new List<Order>();
			ShoppingList = new List<Order>();
		}
		public decimal Checkout()
		{
			decimal totalCost = 0;

			foreach (var c in ShoppingList)
			{
				totalCost += c.price;

			}
			ShoppingList.Clear();
			return totalCost;
		}

		//need to move all of this to WebAPI
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
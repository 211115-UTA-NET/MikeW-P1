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
	}
}
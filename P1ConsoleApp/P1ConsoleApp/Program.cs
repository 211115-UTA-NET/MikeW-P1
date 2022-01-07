using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace P1ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Order order = new Order();

            using (var client = new HttpClient())
            {                               //need to update local host?? - doesn't return anything
                client.BaseAddress = new Uri("https://localhost:7072/swagger/customer.html");

                //HTTP GET
                var responseTask = client.GetAsync("Customer");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Customer[]>();
                    readTask.Wait();

                    var customers = readTask.Result;

                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.CustId);
                    }
                }
            }
            Console.ReadLine();
            // Opening Menu
            Console.WriteLine("Welcome to The Corner Store. \n What do you want to do today?");
            Console.WriteLine("Are you a new Customer?");
            //call customerController?.AddNewCustomer() method        
            //if n then order history?
            //go shopping 
            //if n then : Add new cust - id? name first & last
            //have an option to go back after info is entered

            Console.WriteLine("0. Leave the store.");
            Console.WriteLine("1. Which store do you want to shop at?");
            // MIlwaukee or Madison - utilize a logical OR in if statement
            Console.WriteLine("2. View Order History.");
            Console.WriteLine("3. ");

            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Store.StoreInventoryMilwaukee();
                    break;
                case 2:
                    printShoppingCart(store);
                    break;
                //checkout
                case 3:
                    printShoppingCart(store);
                    Console.WriteLine($"The total cost of your items is: ${store.Checkout()}");
                    //Sql statement - get from P0 
                    Order.AddNewOrderMadison();
                    break;
               
                
                    default:
                    break;
            }

        }
        
        private static void printShoppingCart(Store store)
        {
            Console.WriteLine("You chose to add an item to your cart.");


            Console.WriteLine("What is the item name? apples, bananas, etc.");
            string itemName = Console.ReadLine();

            Console.WriteLine("How many do you want to add to your cart?");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the cost of the item?");
            int price = Convert.ToInt32(Console.ReadLine());
            int totalPrice = quantity * price;

            Console.WriteLine($"The cost of your item is: {totalPrice}");

            Order newOrder = new Order(itemName, quantity, price);
            store.InventoryList.Add(newOrder);

            printShoppingCart(store);
        }
    }
}

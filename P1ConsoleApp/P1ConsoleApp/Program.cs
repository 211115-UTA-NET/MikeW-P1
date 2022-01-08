using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1ConsoleApp
{
    public class Program
    {
        public static readonly HttpClient HttpClient = new();

        public async static Task Main(string[] args)
        {
            //HttpResponseMessage response = await HttpClient.GetAsync($"https://localhost:7255");

            Uri server = new("https://localhost:7255");
            //RpsConsoleApp.UI uses a IGaeservice class here
            //IGameService gameService = new GameService(server);

            Store store = new Store();
            IHttp http = new HttpMethods(server);

            // Opening Menu
            Console.WriteLine("Welcome to The Corner Store. \n What do you want to do today?");

            Console.WriteLine("0. Leave the store.");
            Console.WriteLine("1. Which store do you want to shop at? \n 1) Milwaukee \n 2) Madison");
            // Milwaukee or Madison - utilize a logical OR in if statement

            Console.WriteLine("2. View Order History.");
            Console.WriteLine("3. ");




            //have an option to go back after info is entered

            int input = int.Parse(Console.ReadLine());
            int action = chooseAction();


            switch (input)
            {
                case 1:
                    List<Order> inventory;
                    inventory = await http.GetInventoryListAsync();
                    break;
                case 2:
                    printShoppingCart(store);
                    break;
                //checkout
                case 3:
                    printShoppingCart(store);
                    Console.WriteLine("Are you a new Customer? \n Enter Yes or No.");
                    string ans = Console.ReadLine();
                    if (ans == "yes" || ans == "Yes")
                    {
                        Customer.AddNewCustomer();
                    }
                    Console.WriteLine($"The total cost of your items is: ${store.Checkout()}");
                    //Sql statement - get from P0 
                    Order.AddNewOrderMilwaukee();
                    break;

                default:
                    break;
            }
            switch (input)
            {
                case 1:
                    Store.StoreInventoryMadison();
                    break;
                case 2:
                    printShoppingCart(store);
                    break;
                //checkout
                case 3:
                    printShoppingCart(store);
                    Console.WriteLine("Are you a new Customer? \n Enter Yes or No.");
                    string ans = Console.ReadLine();
                    if (ans == "yes" || ans == "Yes")
                    {
                        Customer.AddNewCustomer();
                    }
                    Console.WriteLine($"The total cost of your items is: ${store.Checkout()}");
                    //Sql statement - get from P0 
                    Order.AddNewOrderMadison();
                    break;

                default:
                    break;
            }
            action = chooseAction();

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
        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Choose an action:\n 0) Quit.\n 1) Show Inventory \n 2) Add items to Cart, \n 3) Checkout.");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return choice;
        }
    }
}

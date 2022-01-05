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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7072/swagger/index.html");

                //HTTP GET
                var responseTask = client.GetAsync("Customer");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Customer[]>();
                    readTask.Wait();

                    var customers = readTask.Result;

                    foreach(var customer in customers)
                    {
                        Console.WriteLine(customer.CustId);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

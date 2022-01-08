using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using P1ConsoleApp.DTOs;

namespace P1ConsoleApp
{
    public class HttpMethods
    {
        private readonly HttpClient _httpClient = new();

        public HttpMethods()
        {
        }

        public HttpMethods(Uri serverUri)
        {
            _httpClient.BaseAddress = serverUri;
        }
        public async Task<List<Order>> GetInventoryListAsync()
        {
            string location = " "; string itemName = " "; string quantity = " "; string price = " ";
            Dictionary<string, string> query = new() { ["Location"] = location, ["ItemName"] = itemName, ["Quantity"] = quantity, ["Price"] = price };
            string requestUri = QueryHelpers.AddQueryString("/api/Store", query); //getting inventory list from store??

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            // telling the server we expect application/json reply. ("content negotiation" in http/rest)
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw new UnexpectedServerBehaviorException("network error", ex);  //exception class
            }

            response.EnsureSuccessStatusCode(); // throw if the status code is not 2xx
            //if (response.StatusCode == 401)
            //{
            //    throw new UnauthorizedException();
            //}

            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {
                throw new UnexpectedServerBehaviorException();
            }

            var inventory = await response.Content.ReadFromJsonAsync<List<Order>>();
            if (inventory == null)
            {
                throw new UnexpectedServerBehaviorException();
            }

            return inventory;
        }
    }
    }

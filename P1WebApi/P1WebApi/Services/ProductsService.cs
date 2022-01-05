using P1WebApi.Models;

namespace P1WebApi.Services
{
    public static class ProductsService
    {
        static List<Products> Item { get; }
        static int nextId = 3;
        static ProductsService()
        {
            Item = new List<Products> //creating a list of product temporarily, will need to pull the list from the DB
            {
                new Products { ProductId = 1, ProductName ="Apples", ProductQuantity = 10},
                new Products { ProductId = 2, ProductName ="Bananas", ProductQuantity= 10}
            };
        }

        public static List<Products> GetAll() => Item;
        public static Products? Get(int id) => Item.FirstOrDefault(p => p.ProductId == id);
        public static void Add(Products product)
        {
            product.ProductId = nextId++;
            Item.Add(product);
        }

        public static void Delete(int id)
        {
            var product = Get(id);
            if (product is null)
                return;
            Item.Remove(product);
        }

        public static void Update(Products product)
        {
            var index = Item.FindIndex(p => p.ProductId == product.ProductId);
            if (index == -1)
                return;

            Item[index] = product;
        }
    }
}

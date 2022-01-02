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
                new Products { Id = 1, Name ="Apples", IsAvailable = true},
                new Products { Id = 2, Name ="Bananas", IsAvailable=true}
            };
        }

        public static List<Products> GetAll() => Item;
        public static Products? Get(int id) => Item.FirstOrDefault(p => p.Id == id);
        public static void Add(Products product)
        {
            product.Id = nextId++;
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
            var index = Item.FindIndex(p => p.Id == product.Id);
            if (index == -1)
                return;

            Item[index] = product;
        }
    }
}

namespace P1WebApi.Models
{
    // list of Inventory
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsAvailable { get; set; } //change to quantity

        //add price
        //add store location
    }
}

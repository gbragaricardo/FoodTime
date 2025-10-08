namespace FoodTime.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category{ get; set; }

        public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}

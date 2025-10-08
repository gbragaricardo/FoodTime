namespace FoodTime.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        IList<Product> Products { get; set; } = new List<Product>();
    }
}

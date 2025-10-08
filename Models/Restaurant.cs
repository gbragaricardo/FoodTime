namespace FoodTime.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public RestaurantStatus? Status { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();
    }

    public enum RestaurantStatus
    {
        Open,
        Closed
    }
}

namespace FoodTime.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal SubTotal { get; set; }

        public int PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public IList<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }
}

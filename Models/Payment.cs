namespace FoodTime.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentMethod Method { get; set; }
        public Decimal Value { get; set; }
        public PaymentStatus Status { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        Cash,
        Pix
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }
}

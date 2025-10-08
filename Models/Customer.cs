using FoodTime.ValueObjects;

namespace FoodTime.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Email? Email { get; set; }
        public string? PasswordHash { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();


        //Methods
        public Customer(string name, Email email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}

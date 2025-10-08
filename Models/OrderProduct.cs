namespace FoodTime.Models
{
    public class OrderProduct
    {
        public int Id { get; set; } // Chave primária do próprio item
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Preço do produto no momento do pedido

        // Chaves estrangeiras para criar as relações
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Propriedades de navegação para o EF Core
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}

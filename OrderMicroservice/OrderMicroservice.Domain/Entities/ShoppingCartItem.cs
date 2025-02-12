namespace OrderMicroservice.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        // Navigation
        public ShoppingCart ShoppingCart { get; set; }
    }
}
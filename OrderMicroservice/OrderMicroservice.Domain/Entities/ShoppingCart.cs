namespace OrderMicroservice.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        // Navigation
        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
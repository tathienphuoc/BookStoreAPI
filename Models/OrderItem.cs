using BookStoreAPI.Interface;

namespace BookStoreAPI.Models
{
    public class OrderItem: IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
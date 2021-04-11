using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class Order_ReceiptBook: IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int Order_ReceiptId { get; set; }
        public virtual Order_Receipt Order_Receipt { get; set; }
    }
    public class Order_ReceiptBookCreateDto
    {
        public int Order_ReceiptId { get; set; }
        public int BookId { get; set; }
    }

    public class Order_ReceiptBookUpdateDto : Order_ReceiptBookCreateDto{
        public int Id { get; set; }
    }
}
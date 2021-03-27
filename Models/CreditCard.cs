using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class CreditCard: IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SerialNumber { get; set; }
        
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
    public class CreditCardCreateDto
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string SerialNumber { get; set; }
    }

    public class CreditCardUpdateDto : CreditCardCreateDto
    {
        public int Id { get; set; }
    }
}
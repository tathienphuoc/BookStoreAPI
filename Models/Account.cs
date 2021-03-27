using BookStoreAPI.Interface;
using System.Collections;
using System.Collections.Generic;
namespace BookStoreAPI.Models
{//1 account co >=0 review, >=0 order_receipt, (0,1) card, 1 shoppingcart
    public class Account: IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? HomeAddress { get; set; }
        public string Image { get; set; } = "https://www.pngitem.com/pimgs/m/421-4213053_default-avatar-icon-hd-png-download.png";
        public bool IsBlocked { get; set; } = false;
        public AccountRole Role { get; set; } = AccountRole.Customer;

        public virtual CreditCard CreditCard { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        
        public virtual ICollection<Order_Receipt> Order_Receipts { get; set; }
    
        public enum AccountRole{
            Customer, //Default
            Employee,
            Admin
        }

    }
    public class AccountCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public int CreditCardId { get; set; }
        public bool IsBlocked { get; set; }
        public string Role { get; set; }
    }

    public class AccountUpdateDto : AccountCreateDto
    {
        public int Id { get; set; }
    }
}
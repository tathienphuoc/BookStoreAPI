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
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public string Image { get; set; } 
        public bool IsBlocked { get; set; }
        public AccountRole Role { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual List<Review> Reviews { get; set; }
        
        public virtual List<Order_Receipt> Order_Receipts { get; set; }
    
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
        public string Image { get; set; } 
        public bool IsBlocked { get; set; }
        public int Role { get; set; }

        public List<Review> Reviews { get; set; }
        
        public List<Order_Receipt> Order_Receipts { get; set; }
    }

    public class AccountUpdateDto : AccountCreateDto
    {
        public int Id { get; set; }
    }
}
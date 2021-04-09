using BookStoreAPI.Interface;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
namespace BookStoreAPI.Models
{//1 account co >=0 review, >=0 order_receipt, (0,1) card, 1 shoppingcart
    public class Account: IdentityUser<int>, IEntity
    {
        public string FullName { get; set; }
        public string HomeAddress { get; set; }
        public string Image { get; set; } 
        public bool IsBlocked { get; set; }
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
    public class UserDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
    }
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AccountCreateDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Image { get; set; }     
    }

    public class AccountUpdateDto : AccountCreateDto
    {
        public int Id { get; set; }
    }
}
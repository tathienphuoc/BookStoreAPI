using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BookStoreAPI.Helpers;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Service
{
  public class AccountService
  {
    private AccountRepository repository;
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountService(AccountRepository AccountRepository,UserManager<Account> userManager, RoleManager<AppRole> roleManager)
    {
      this.repository = AccountRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

    public List<Account> GetAll()
    {
      return repository.FindAll();
    }

    public Account GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public Account GetDetail(string email)
    {
      email = FormatString.Trim_MultiSpaces_Title(email);
      return repository.FindAll().Where(c => c.Email.Equals(email)).FirstOrDefault();
    }

    public async Task<Account> GetUserByIdAsync(int id)
        {
            return await repository.context.Users.FindAsync(id);
        }

        public async Task<Account> GetUserByUsernameAsync(string username)
        {
            return await repository.context.Users
                .Include(p => p.Reviews)
                .Include(p => p.Order_Receipts)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<PagedList<Account>> GetMembersAsync(UserParams user)
        {
            var query = repository.context.Users.AsQueryable();
            query = query.Where(u => u.UserName != user.CurrentUserName);            
            // query = user.OrderBy switch 
            // {
            //     "created" => query.OrderByDescending(u => u.Created),
            //     _ => query.OrderByDescending(u => u.LastActive)
            // };

            return await PagedList<Account>.CreateAsync(query,
                    user.pageNumber,user.pageSize);
            
        }

        public async Task<IEnumerable<Account>> GetUsersAsync()
        {
            return await repository.context.Users
                .Include(p => p.Reviews)
                .Include(p => p.Order_Receipts)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await repository.context.SaveChangesAsync() > 0;
        }

        public void Update(Account user)
        {
            repository.context.Entry(user).State = EntityState.Modified;
        }
  }
}
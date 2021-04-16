using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using BookStoreAPI.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Service
{
    public class ReviewService
    {
        public ReviewRepository repository;
        private readonly UserManager<Account> _userManager;

        public ReviewService(ReviewRepository ReviewRepository, UserManager<Account> userManager)
        {
            this.repository = ReviewRepository;
            _userManager = userManager;
        }

        public List<Review> GetAll()
        {
            return repository.FindAll();
        }

        public Review GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public async Task<Review> GetUserReview(int userId, int bookId)
        {
            return await repository.context.Reviews.FindAsync(userId, bookId);
        }

        public async Task<List<Review>> GetAllReview() 
        {
            return await repository.context.Reviews.ToListAsync();
        }

        public async Task<PagedList<Review>> GetUserReviews(ReviewParams reviewParams)
        {
            // var books = repository.context.Books.OrderBy(x=>x.Title).AsQueryable();
            var reviews = repository.context.Reviews.AsQueryable();
            
            reviews = reviews.Where(r => r.AccountId == reviewParams.UserId);

            return await PagedList<Review>.CreateAsync(reviews, reviewParams.pageNumber, 
                reviewParams.pageSize);
        }

        public async Task<Account> GetUserWithReviews(int userId)
        {
            return await _userManager.Users
                .Include(l => l.Reviews)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
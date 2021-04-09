using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Helpers;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
     public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;
        private readonly BookService _bookService;
        private readonly UserManager<Account> _userManager;

        public ReviewController(ReviewService reviewService, BookService bookService,
            UserManager<Account> userManager)
        {
            _reviewService = reviewService;
            _bookService = bookService;
            _userManager = userManager;
        }

        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview(ReviewDto reviewDto)
        {  
            var userId = User.GetUserId();
            
            var book = _bookService.GetDetail(reviewDto.BookId); //Get User duoc Like
            var user = await _reviewService.GetUserWithReviews(userId);  // Get minh ra tu bang like

            if(book == null) return NotFound();

            var userReview = await _reviewService.GetUserReview(userId, reviewDto.BookId);
            if(userReview != null) return BadRequest("Bạn đã thích Sách này");

            userReview = new Review 
            {
                AccountId = userId,
                BookId = reviewDto.BookId,
                CreatedAt = DateTime.Now,
                Content = reviewDto.Content,
                Liked = true
            };
            _reviewService.repository.context.Reviews.Add(userReview);
            if(await _reviewService.repository.context.SaveChangesAsync() >0) return Ok(userReview);

            return BadRequest("Có lỗi xảy ra");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetUserLikes([FromQuery]ReviewParams reviewParams)
        {
            reviewParams.UserId = User.GetUserId();
            var result = await _reviewService.GetUserReviews(reviewParams);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return Ok(result); 
        }
    }
}
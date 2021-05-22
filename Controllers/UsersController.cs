using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStoreAPI.Data;
using BookStoreAPI.Helpers;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Service;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public UsersController(AccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetUsers([FromQuery]UserParams userParams)
        {
            var user = await _accountService.GetUserByUsernameAsync(User.GetUsername());
            userParams.CurrentUserName = user.UserName;
            var result = await _accountService.GetMembersAsync(userParams);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize,
                 result.TotalCount, result.TotalPages);

            return Ok(result);
        }

        [HttpGet("{username}", Name="GetUser")]
        public async Task<ActionResult<UserDto>> GetUserByUserName(string username)
        {
            var user = await _accountService.GetUserByUsernameAsync(username);
            var userToReturn = _mapper.Map<MemberDto>(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(AccountUpdateDto accountUpdateDto)
        {
            var user = await _accountService.GetUserByUsernameAsync(User.GetUsername());
            _mapper.Map(accountUpdateDto, user);
            _accountService.Update(user);
            if (await _accountService.SaveAllAsync()) return NoContent();

            return BadRequest("Fail to update user");
        }

        [HttpPut("block/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> BlockUser(int userId)
        {
            var user = await _accountService.GetUserByIdAsync(User.GetUserId());
            user.IsBlocked = true;
            _accountService.Update(user);
            if (await _accountService.SaveAllAsync()) return NoContent();

            return BadRequest("Fail to block user");
        }

        [HttpPut("unblock/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UnblockBlockUser(int userId)
        {
            var user = await _accountService.GetUserByIdAsync(User.GetUserId());
            user.IsBlocked = false;
            _accountService.Update(user);
            if (await _accountService.SaveAllAsync()) return NoContent();

            return BadRequest("Fail to block user");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Helpers;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(UserManager<Account> userManager,
                ITokenService tokenService, IMapper mapper, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpPost("{register}")]
        public async Task<ActionResult<UserDto>> Register(AccountCreateDto register)
        {
            var userFb = await _userManager.FindByEmailAsync(register.Email);
            var user = await _userManager.FindByNameAsync(register.UserName);
            if (userFb != null && register.Image != null) // Đăng ký bằng fb
            {
                var temp = new UserDto()
                {
                    Id = userFb.Id,
                    Username = userFb.UserName,
                    FullName = register.FullName,
                    Token = await _tokenService.CreateTokenAsync(userFb),
                    HomeAddress = userFb.HomeAddress,
                    Email = userFb.Email,
                    Image = register.Image,
                    PhoneNumber = userFb.PhoneNumber
                };
                if (userFb.Image == null)
                {
                    var account = await _userManager.FindByIdAsync(userFb.Id.ToString());
                    account.FullName = register.FullName;
                    account.Image = register.Image;
                    await _userManager.UpdateAsync(account);
                }
                return temp;
            }
            else if (userFb != null && register.Image == null) // Đăng ký bình thường
            {
                return BadRequest("Email is taken");

            }

            if (user != null || userFb != null)
            {
                return BadRequest("Username is taken");
            }

            user = _mapper.Map<Account>(register);
            IdentityResult result = null;
            if (string.IsNullOrEmpty(register.Password))
            {
                result = await _userManager.CreateAsync(user, "123456");
            }
            else
            {
                result = await _userManager.CreateAsync(user, register.Password);
            }

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Customer");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                FullName = user.FullName,
                Token = await _tokenService.CreateTokenAsync(user),
                HomeAddress = user.HomeAddress,
                Email = user.Email,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == login.Username);
            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) return Unauthorized("Incorrect Password");
            return new UserDto()
            {
                Id = user.Id,
                FullName = user.FullName,
                Token = await _tokenService.CreateTokenAsync(user),
                HomeAddress = user.HomeAddress,
                Image = user.Image,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName,
            };
        }


    }
}
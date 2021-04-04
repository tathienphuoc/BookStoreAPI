using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, 
                ITokenService tokenService, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpPost("{register}")]
        public async Task<ActionResult<UserDto>> Register(AccountCreateDto register)
        {
            var user = await _userManager.FindByNameAsync(register.UserName);     
            if(user != null) return BadRequest("Username is taken");

            user = _mapper.Map<AppUser>(register);

            var result = await _userManager.CreateAsync(user,register.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            return new UserDto()
            {
                Username = user.UserName,
                FullName = user.FullName,
                Token = _tokenService.CreateToken(user),
                HomeAddress = user.HomeAddress,
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

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password,false);
            if(!result.Succeeded) return Unauthorized();
            return new UserDto()
            {
                FullName = user.FullName,
                Token = _tokenService.CreateToken(user),
                HomeAddress = user.HomeAddress,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
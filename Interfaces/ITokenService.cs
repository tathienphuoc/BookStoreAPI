using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
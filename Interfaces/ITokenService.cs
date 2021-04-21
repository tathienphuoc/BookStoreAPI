using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(Account user);
    }
}
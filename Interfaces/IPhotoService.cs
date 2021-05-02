using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace BookStoreAPI.Interfaces
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> AddPhotoAsync(IFormFile fromFile);
        //  Task<DeletionResult> DeletePhotoAsync(string publicId);


    }
}
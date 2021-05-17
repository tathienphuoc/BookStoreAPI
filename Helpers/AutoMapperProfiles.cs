using System.Linq;
using BookStoreAPI.Models;
using AutoMapper;

namespace BookStoreAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AccountCreateDto, Account>();
            CreateMap<Account, MemberDto>();
            CreateMap<UserDto, Account>();
            CreateMap<UserDto, Account>().ReverseMap();
            CreateMap<AccountUpdateDto, Account>();
            CreateMap<CartItem, OrderItem>();
            // CreateMap<Photo, PhotoDto>();
            // CreateMap<MemberUpdateDto, AppUser>();
            // CreateMap<RegisterDto, AppUser>();
            // CreateMap<Message, MessageDto>()
            //     .ForMember(dest => dest.SenderPhotoUrl, opt => opt
            //     .MapFrom(src => src.Sender.Photos.FirstOrDefault(x=>x.IsMain).Url))
            //     .ForMember(dest => dest.RecipientPhotoUrl, opt => opt
            //     .MapFrom(src => src.Recipient.Photos.FirstOrDefault(x=>x.IsMain).Url));
        }
    }
}
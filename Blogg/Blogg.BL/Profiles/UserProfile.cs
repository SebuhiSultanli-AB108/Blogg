using AutoMapper;
using Blogg.BL.DTOs.UserDTOs;
using Blogg.BL.Helpers;
using Blogg.Core.Entities;

namespace Blogg.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDTO, User>()
            .ForMember(x => x.PasswordHash, x => x.MapFrom(y => HashHelper.HashPassword(y.Password)));
    }
}

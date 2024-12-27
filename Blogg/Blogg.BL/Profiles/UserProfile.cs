using AutoMapper;
using Blogg.BL.DTOs.UserDTOs;
using Blogg.Core.Entities;

namespace Blogg.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDTO, User>().ReverseMap();
    }
}

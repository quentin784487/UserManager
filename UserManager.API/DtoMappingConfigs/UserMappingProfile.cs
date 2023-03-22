using AutoMapper;
using UserManager.API.Models.User;
using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;

namespace UserManager.API.DtoMappingConfigs
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<UserCore, User>();
            CreateMap<User, UserCore>();
        }
    }
}

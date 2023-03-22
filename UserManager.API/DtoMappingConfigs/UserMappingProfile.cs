using AutoMapper;
using UserManager.API.Models.User;
using UserManager.Core.Domain.Entities;

namespace UserManager.API.DtoMappingConfigs
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}

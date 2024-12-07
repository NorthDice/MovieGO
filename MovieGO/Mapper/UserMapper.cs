using AutoMapper;
using MovieGO.Entities;
using MovieGO.Models.UserData;

namespace MovieGO.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
        }
    }
}

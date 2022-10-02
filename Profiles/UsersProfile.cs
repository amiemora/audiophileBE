using AutoMapper;


namespace AudiophileBE.Profiles
{
    public class UsersProfile : Profile
    {
      
            public UsersProfile()
            {
                CreateMap<Entities.User, Models.UserDto>();
                 CreateMap<Entities.User, Models.UserOnlyDto>();
                CreateMap<Entities.User, Models.UserCreateDto>();
                CreateMap<Entities.User, Models.UserUpdateDto>();
                CreateMap<Entities.User, Models.UserLoginDto>();
            }
        
    }
}

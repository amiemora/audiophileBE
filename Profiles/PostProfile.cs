using AutoMapper;

namespace AudiophileBE.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Entities.Post, Models.PostDto>();
            CreateMap<Entities.Post, Models.PostCreateDto>();
        }
    }
}

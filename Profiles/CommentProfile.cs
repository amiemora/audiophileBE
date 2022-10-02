using AutoMapper;


namespace AudiophileBE.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Entities.Comment, Models.CommentDto>();
            CreateMap<Entities.Comment, Models.CommentCreateDto>();
        }
    }
}

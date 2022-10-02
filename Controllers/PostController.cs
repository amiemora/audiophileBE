using AudiophileBE.Models;
using AudiophileBE.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudiophileBE.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPost()
        {
            var postEntities = await _postRepository.GetAllPostAsync();

            return Ok(_mapper.Map<IEnumerable<PostDto>>(postEntities));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var postEntities = await _postRepository.GetPostAsync(id);

            return Ok(_mapper.Map<PostDto>(postEntities));

        }

        [HttpPost]
        public async Task<ActionResult<PostCreateDto>> CreatePost(int userId, string songTitle, string album, string artist)
        {
            var postEntity = await _postRepository.CreatePostAsync(userId, songTitle, album, artist);
 
            return Ok();
        }
    }
}

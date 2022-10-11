using AudiophileBE.Models;
using AudiophileBE.Services;
using AutoMapper;
using AudiophileBE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudiophileBE.DbContexts;

namespace AudiophileBE.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly AudiophileContext _context;
        private readonly IConfiguration _configuration;

        public PostController(AudiophileContext _context, IConfiguration _configuration, IPostRepository postRepository, IMapper mapper)
        {
            this._context = _context;
            this._configuration = _configuration;
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
        public async Task<ActionResult<PostDto>> GetUser(int id)
        {
            var postEntities = await _postRepository.GetPostAsync(id);

            return Ok(_mapper.Map<PostDto>(postEntities));

        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(PostDto model)
        {

            try
            {
                var _post = new Post();
                _post.UserID = model.UserId;
                _post.song_title = model.song_title;
                _post.album = model.Album;
                _post.artist = model.Artist;
                _context.Post.Add(_post);
                await _context.SaveChangesAsync();
                return Ok("Successfully created Post.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

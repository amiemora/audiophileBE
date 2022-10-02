using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudiophileBE.Models;
using AudiophileBE.Services;
using AutoMapper;

namespace AudiophileBE.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllComment()
        {
            var commentEntities = await _commentRepository.GetAllCommentAsync();

            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentEntities));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var commentEntities = await _commentRepository.GetCommentAsync(id);

            return Ok(_mapper.Map<CommentDto>(commentEntities));

        }

        [HttpPost]
        public async Task<ActionResult<CommentCreateDto>> CreateComment(int userId, int postId, string commentBody)
        {
            var commentEntity = await _commentRepository.CreateCommentAsync(userId, postId, commentBody);

            return Ok();
        }
    }
}

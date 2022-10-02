using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudiophileBE.Models;
using AudiophileBE.Tools;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using AudiophileBE.Services;
using AudiophileBE.Entities;
using AutoMapper;

namespace AudiophileBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOnlyDto>>> GetUsers()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserOnlyDto>>(userEntities));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var userEntities = await _userRepository.GetUserAsync(id);

            return Ok(_mapper.Map<UserDto>(userEntities));

        }
    }
}

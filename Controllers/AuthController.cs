using AudiophileBE.DbContexts;
using AudiophileBE.Entities;
using AudiophileBE.Models;
using AudiophileBE.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudiophileBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AudiophileContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(AudiophileContext _context, IConfiguration _configuration)
        {
           this._context =  _context;
          this._configuration = _configuration;
         }

        [HttpPost]
         [Route("login")]
         public async Task<IActionResult> UserLogin([FromBody] User user)
          {
            try
          {
            String password = Password.HashPassword(user.Password);
          var dbUser =  _context.Users.Where(u => u.Username == user.Username &&  u.Password == password).Select(u => new
        {
          u.UserId,
            u.Username,
               u.Name
           }).FirstOrDefault();
            if (dbUser == null)
            {
              return BadRequest("Username or Password is incorrect");
           }
            return Ok(dbUser);
         }
           catch (Exception e)
            {
                return BadRequest(e.Message);
             }
           }
            [HttpPost]
           [Route("register")]
            public async Task<IActionResult> UserRegistration([FromBody] UserDto user)
            {
                try
               {
                   var dbUser = _context.Users.Where(u => u.Username == user.Username).FirstOrDefault();
                   if (dbUser != null)
                  {
                     return BadRequest("Username already exists");
                 }
                var _user = new User();
                  _user.Name = user.Name;
                 _user.Username = user.Username;
                _user.Password = Password.HashPassword(user.Password);
                 _context.Users.Add(_user);
                  await _context.SaveChangesAsync();
                return Ok("User successfully registered.");
              }
                catch (Exception ex)
                {
                 return BadRequest(ex.Message);
               }
            }

    }
}

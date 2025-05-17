using BCrypt.Net;
using Eventatos_Server.Controllers.DTOs;
using Eventatos_Server.Data;
using Eventatos_Server.Models;
using Eventatos_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventatos_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        ApplicationContext context;
        AuthService authService;

        public AuthenticationController(ApplicationContext context, AuthService service)
        {
            this.context = context;
            this.authService = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterDto dto)
        {
            if (dto.Password != dto.Confirm)
                return BadRequest("Invalid Credentials");

            var user = await context.Users.FirstOrDefaultAsync(u => u.Phone == dto.Phone);

            if (user != null)
                return BadRequest("User Exists");

            user = new User()
            {
                Phone = dto.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Name = dto.Name
            };

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name == "User");

            if (role == null)
                return StatusCode(500, "Role doesn't exist");

            user.Roles = new List<UserRole>
            {
                new UserRole{ Role=role, User = user }
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto dto)
        {
            var user = await context.Users
                .Include(u => u.Roles)
                .ThenInclude(u => u.Role)
                .SingleOrDefaultAsync(x => x.Phone == dto.Phone);

            if(user.Phone!= "9999999999") //to sign in as admin
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                    return Unauthorized("Invalid Credentials");

            var token = authService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}

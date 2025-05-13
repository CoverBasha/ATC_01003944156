using Eventatos_Server.Data;
using Eventatos_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventatos_Server.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        ApplicationContext context;

        public AdminController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("allEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await context.Events.ToListAsync();
            return Ok(result);
        }
    }
}

using Eventatos_Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventatos_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        ApplicationContext context;

        public EventsController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> events()
        {
            return Ok(await context.Events.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> details(int id)
        {
            var vent = await context.Events.SingleOrDefaultAsync(x => x.Id == id);

            return vent == null ? NotFound() : Ok(vent);

        }
    }
}

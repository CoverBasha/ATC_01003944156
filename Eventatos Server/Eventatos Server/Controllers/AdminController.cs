using Eventatos_Server.Controllers.DTOs;
using Eventatos_Server.Data;
using Eventatos_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        [HttpGet("getEvents")]
        public async Task<IActionResult> getEvents()
        {
            var result = await context.Events.ToListAsync();
            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> details(int id)
        {
            var vent = await context.Events.SingleOrDefaultAsync(e => e.Id == id);

            if (vent == null)
                return NotFound("Event doesn't exist");

            return Ok(vent);
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(EventDto dto)
        {
            var vent = new Event
            {
                Name = dto.Name,
                Description = dto.Description,
                Tickets = dto.Tickets,
                Date = dto.Date,
                Venue = dto.Venue,
                Price = dto.Price,
                ImageURL = dto.ImageURL
            };

            await context.Events.AddAsync(vent);
            await context.SaveChangesAsync();

            return Ok(vent.Id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> edit(int id,EventDto dto)
        {
            var ventInDB = await context.Events.SingleOrDefaultAsync(e => e.Id == id);

            if (ventInDB == null)
                return NotFound("Event doesn't exist");

            ventInDB.Name = dto.Name;
            ventInDB.Description = dto.Description;
            ventInDB.Tickets = dto.Tickets;
            ventInDB.Date = dto.Date;
            ventInDB.Venue = dto.Venue;
            ventInDB.Price = dto.Price;
            ventInDB.ImageURL = dto.ImageURL;

            await context.SaveChangesAsync();

            return Ok(ventInDB.Id);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var vent = await context.Events.SingleOrDefaultAsync(e => e.Id == id);

            if (vent == null)
                return NotFound("Event doesn't exist");

            context.Events.Remove(vent);
            await context.SaveChangesAsync();

            return Ok("Event deleted");
        }
    }
}

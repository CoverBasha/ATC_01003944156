using Eventatos_Server.Data;
using Eventatos_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Security.Provider;
using System.Security.Claims;

namespace Eventatos_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class BookingsController : ControllerBase
    {
        ApplicationContext context;

        public BookingsController(ApplicationContext context)
        {
            this.context = context;
        }

        int getId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return -1;
            var id = int.Parse(userId);

            return id;
        }

        [HttpGet]
        public async Task<IActionResult> getBookings()
        {
            var id = getId();
            if (id == -1)
                return Unauthorized("Token not found");

            var bookings = await context.Bookings.Where(u => u.UserId == id).ToListAsync();
            return Ok(bookings);
        }

        [HttpPost("{eventId}")]
        public async Task<IActionResult> bookEvent(int eventId)
        {
            var id = getId();
            if (id == -1)
                return Unauthorized("Token not found");

            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            var vent = await context.Events.SingleOrDefaultAsync(e => e.Id == eventId);

            if (vent == null)
                return NotFound("Event not found");

            var alreadyBooked = await context.Bookings.AnyAsync(b => b.UserId == id && b.EventId == eventId);
            if (alreadyBooked)
                return BadRequest("event already booked.");

            if (vent.Tickets == 0)
                return BadRequest("No tickets available");

            var booking = new Booking
            {
                EventId = eventId,
                UserId = id,
                Event = vent,
                User = user,
                BookedAt = DateTime.UtcNow
            };

            vent.Tickets--;
            vent.Bookings.Add(booking);

            await context.Bookings.AddAsync(booking);

            await context.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> cancel(int bookingId)
        {
            var id = getId();
            if (id == -1)
                return Unauthorized("Token not found");

            var booking = await context.Bookings.SingleOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                return NotFound("No such booking");
            var vent = await context.Events.SingleOrDefaultAsync(e => e.Id == booking.EventId);
            if (vent == null)
                return NotFound("Event doesn't exist");
            vent.Tickets++;

            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
            return Ok("Booking Cancelled");
        }
    }
}

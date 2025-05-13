using Microsoft.AspNetCore.Authentication;

namespace Eventatos_Server.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Tickets { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}

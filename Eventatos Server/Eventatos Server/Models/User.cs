using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Eventatos_Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}

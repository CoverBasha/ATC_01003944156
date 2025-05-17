namespace Eventatos_Server.Controllers.DTOs
{
    public class EventDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Tickets { get; set; }
    }
}

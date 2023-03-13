namespace Events.Models
{
    public class EventTypeDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}

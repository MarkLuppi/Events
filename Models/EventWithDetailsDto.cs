using System.ComponentModel.DataAnnotations;

namespace Events.Models
{
    public class EventWithDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime? Date { get; set; }
   
        public string? Notes { get; set; }
        public EventTypeDto? EventType { get; set; } = null!;


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("EventTypeId")]
        public EventType? EventType { get; set; }
        public int EventTypeId { get; set; }


        public Event(string title)
        {
            Title = title;
        }
      

        
    }
}

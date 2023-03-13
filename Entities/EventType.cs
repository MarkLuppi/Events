using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Entities
{
    public class EventType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)] 
        public string? Title { get; set; }
        public string? Description { get; set; }


        public EventType(string title)
        {
            Title = title;
        }
    }
}
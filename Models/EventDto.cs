using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events.Models
{

    public class EventDto
    {

        public int Id { get; set; }


        public string Title { get; set; } = null!;
        public DateTime? Date { get; set; }
  


    }
}

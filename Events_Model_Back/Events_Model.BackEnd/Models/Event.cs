using System.ComponentModel.DataAnnotations;

namespace Events_Model.BackEnd.Models
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public EventLocation Location { get; set; } = null!;
    }
}

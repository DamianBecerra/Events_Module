using System.ComponentModel.DataAnnotations;

namespace Events_Model.BackEnd.Models
{
    public class EventLocation
    {
        [Key]
        public int IdLocation { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; } = string.Empty;

        public int IdEvent { get; set; }

    }
}

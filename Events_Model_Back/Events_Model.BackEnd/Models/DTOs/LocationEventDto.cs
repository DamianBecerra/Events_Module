namespace Events_Model.BackEnd.Models.DTOs
{
    public class LocationEventDto
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}

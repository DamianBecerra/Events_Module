namespace Events_Model.BackEnd.Models.DTOs
{
    public class Pagination<T> where T : IEnumerable<object>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalEvents {  get; set; }
        public T Data { get; set; } = default!;
    }
}

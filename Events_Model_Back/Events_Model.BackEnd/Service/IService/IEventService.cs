using Events_Model.BackEnd.Models.DTOs;

namespace Events_Model.BackEnd.Service.IService
{
    public interface IEventService
    {
        Task<Pagination<IEnumerable<EventDto>>> GetEventAsync(DateTime? date, int page, int pageSize);

        Task<EventDto?> GetEventbyIdAsync(int id);
    }
}

using Events_Model.BackEnd.Models;
using Events_Model.BackEnd.Models.DTOs;

namespace Events_Model.BackEnd.Repository.IRepository
{
    public interface IEventrepository
    {
        Task<(IEnumerable<Event> Items, int totalEvents)> GetEventsAsync(DateTime? startDate, DateTime? endDate, int page, int pageSize);

        Task<Event?> GetByIdAsync(int id);
    }
}

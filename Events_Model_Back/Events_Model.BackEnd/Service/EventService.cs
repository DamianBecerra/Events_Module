using Events_Model.BackEnd.Models.DTOs;
using Events_Model.BackEnd.Repository.IRepository;
using Events_Model.BackEnd.Service.IService;

namespace Events_Model.BackEnd.Service
{
    public class EventService : IEventService
    {
        private readonly IEventrepository _repository;

        public EventService(IEventrepository repository)
        {
            _repository = repository;
        }

        public async Task<Pagination<IEnumerable<EventDto>>> GetEventAsync(DateTime? date, int page, int pageSize)
        {
            var (items, totalEvents) = await _repository.GetEventsAsync(date, page, pageSize);

            var dtos = items.Select(e => new EventDto
            {
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = new LocationEventDto
                {
                    Lat = e.Location.Lat,
                    Long = e.Location.Lng,
                    Address = e.Location.Address
                }
            });

            var totalPages = (int)Math.Ceiling((double)totalEvents / pageSize);

            return new Pagination<IEnumerable<EventDto>>
            {
                CurrentPage = page,
                TotalPages = totalPages,
                TotalEvents = totalEvents,
                Data = dtos
            };
        }

        public async Task<EventDto?> GetEventbyIdAsync(int id)
        {
            var eventSelected = await _repository.GetByIdAsync(id);

            if (eventSelected == null) return null;

            return new EventDto
            {
                Title = eventSelected.Title,
                Description = eventSelected.Description,
                Date = eventSelected.Date,
                Location = new LocationEventDto
                {
                    Lat = eventSelected.Location.Lat,
                    Long = eventSelected.Location.Lng,
                    Address = eventSelected.Location.Address
                }
            };
        }
    }
}

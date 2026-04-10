using Events_Model.BackEnd.Data;
using Events_Model.BackEnd.Models;
using Events_Model.BackEnd.Models.DTOs;
using Events_Model.BackEnd.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Events_Model.BackEnd.Repository
{
    public class EventRepository : IEventrepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Event> Items, int totalEvents)> GetEventsAsync(DateTime? date, int page, int pageSize)
        {
            //query de consulta para los eventos con sus locaciones
            var query = _context.Events
                .Include(e => e.Location)
                .AsNoTracking();

            if (date.HasValue)
            {
                query = query.Where(e => e.Date.Date == date.Value.Date);
            }

            var totalEvents = await query.CountAsync();

            //paginacion
            var items = await query
                .OrderBy(e => e.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            return (items, totalEvents);
        }

        public async Task<Event?> GetByIdAsync(int id) 
        {
            return await _context.Events
                .Include(e => e.Location)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEvent == id);
        }
    }
}

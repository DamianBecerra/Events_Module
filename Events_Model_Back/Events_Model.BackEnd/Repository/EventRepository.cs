using Events_Model.BackEnd.Data;
using Events_Model.BackEnd.Models;
using Events_Model.BackEnd.Models.DTOs;
using Events_Model.BackEnd.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Events_Model.BackEnd.Repository
{
    public class EventRepository : IEventrepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Event> Items, int totalEvents)> GetEventsAsync(DateTime? startDate, DateTime? endDate, int page, int pageSize)
        {
            //query de consulta para los eventos con sus locaciones
            var query = _context.Events
                .Include(e => e.Location)
                .AsNoTracking();

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Date.Date >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Date.Date <= endDate.Value.Date);
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

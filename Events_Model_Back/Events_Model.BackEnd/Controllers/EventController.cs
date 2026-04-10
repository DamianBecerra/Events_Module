using Events_Model.BackEnd.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Events_Model.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Getall(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
            )
        {
            if (page <= 0) page = 1;

            var response = await _service.GetEventAsync(startDate, endDate, page, pageSize);
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetEventbyIdAsync(id);
            if (response == null) return NotFound(new {Message = $"No es posible encontrar el evento {id}"});
            return Ok(response);
        }
    }
}

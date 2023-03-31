using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.BL;
using Tickets.DAL;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketManager _ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        [HttpGet]
        public ActionResult<List<TicketReadDTO>> GetAll()
        {
            return _ticketManager.GetAll();
        }

        [HttpPost]
        public ActionResult Add(TicketWriteDTO ticketDto)
        {
            _ticketManager.Add(ticketDto);
            Console.WriteLine("added successfully");
            return NoContent();
        }
    }
}

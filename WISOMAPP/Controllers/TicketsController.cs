using MediatR; 
using Microsoft.AspNetCore.Mvc;
using WISOMAPP.Application.UseCases.Tickets.Commands; 

namespace WISOMAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            var newTicketId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTicketById), new { id = newTicketId }, newTicketId);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTicketById(Guid id)
        {
            return Ok(new { Message = $"Placeholder: Próximo paso será implementar la consulta (Query) para el ID: {id}" });
        }
    }
}
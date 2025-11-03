using MediatR; 
using Microsoft.AspNetCore.Mvc;
using WISOMAPP.Application.UseCases.Tickets.Commands; 
using WISOMAPP.Application.UseCases.Tickets.Queries;

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
        public async Task<IActionResult> GetTicketById(Guid id) 
        {
            var query = new GetTicketByIdQuery(id);
            
            var ticket = await _mediator.Send(query);
            
            return Ok(ticket);
        }
        
    }
}
using MediatR;
using WISOMAPP.Domain.Entities;       
using WISOMAPP.Application.Interfaces; 
using AutoMapper;                   

namespace WISOMAPP.Application.UseCases.Tickets.Commands
{
    public record CreateTicketCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; } 
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
    
    internal sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // 1. Mapear el Comando (DTO) a la Entidad del Dominio
            var ticket = _mapper.Map<Ticket>(request);

            // 2. Establecer valores por defecto (lógica de negocio)
            ticket.Status = "abierto";
            ticket.CreatedAt = DateTime.UtcNow;

            // 3. Usar el repositorio para añadir la entidad
            _unitOfWork.Repository<Ticket>().AddEntity(ticket);

            // 4. Guardar los cambios en la base de datos
            await _unitOfWork.Complete();

            // 5. Devolver el ID del nuevo ticket
            return ticket.TicketId;
        }
    }
}
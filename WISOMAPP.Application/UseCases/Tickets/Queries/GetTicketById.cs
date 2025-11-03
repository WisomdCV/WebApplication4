using MediatR;
using WISOMAPP.Application.Interfaces;
using WISOMAPP.Application.UseCases.Tickets.DTOs; // Importa el DTO
using WISOMAPP.Domain.Entities;
using AutoMapper;

namespace WISOMAPP.Application.UseCases.Tickets.Queries
{
    public record GetTicketByIdQuery(Guid Id) : IRequest<TicketResponse>;
    
    internal sealed class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTicketByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TicketResponse> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.Repository<Ticket>()
                .GetByIdAsync(request.Id);

            if (ticket == null)
            {
                throw new Exception($"Ticket con ID {request.Id} no encontrado."); 
            }
            
            var response = _mapper.Map<TicketResponse>(ticket);
            
            return response;
        }
    }
}
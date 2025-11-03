using AutoMapper;
using WISOMAPP.Domain.Entities;
using WISOMAPP.Application.UseCases.Tickets.Commands;

namespace WISOMAPP.Application.Mappings
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            // Aquí definimos la regla de "traducción":

            CreateMap<CreateTicketCommand, Ticket>();

            // ... Aquí pondrás más mapeos en el futuro
        }
    }
}
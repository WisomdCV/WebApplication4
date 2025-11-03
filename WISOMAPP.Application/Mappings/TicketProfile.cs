using AutoMapper;
using WISOMAPP.Domain.Entities;
using WISOMAPP.Application.UseCases.Tickets.Commands;
using WISOMAPP.Application.UseCases.Tickets.DTOs;

namespace WISOMAPP.Application.Mappings
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            // Aquí definimos la regla de "traducción":

            CreateMap<CreateTicketCommand, Ticket>();

            CreateMap<Ticket, TicketResponse>();
        }
    }
}
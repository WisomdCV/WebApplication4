namespace WISOMAPP.Domain.Entities
{
    public class Response
    {
        public Guid ResponseId { get; set; }
        public Guid TicketId { get; set; }
        public Guid ResponderId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public Ticket Ticket { get; set; } = null!;
        public User Responder { get; set; } = null!;
    }
}
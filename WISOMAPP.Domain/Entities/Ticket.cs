namespace WISOMAPP.Domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!; // "abierto", "en_proceso", "cerrado"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }

        // Propiedades de navegación
        public User User { get; set; } = null!;
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
}
namespace WISOMAPP.Application.UseCases.Tickets.DTOs
{
    public record TicketResponse
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        
    }
}
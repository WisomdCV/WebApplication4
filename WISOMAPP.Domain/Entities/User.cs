namespace WISOMAPP.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
}
namespace WISOMAPP.Domain.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        // Propiedad de navegación (Un rol tiene muchos UserRoles)
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
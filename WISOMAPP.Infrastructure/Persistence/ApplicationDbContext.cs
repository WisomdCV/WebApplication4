using Microsoft.EntityFrameworkCore;
using WISOMAPP.Domain.Entities; 

namespace WISOMAPP.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Registra tus entidades como "DbSet"
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- CONFIGURACIÓN DE NOMBRES ---
            // Le decimos a EF que use los nombres exactos de tu script SQL
            
            // Tabla "roles"
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("roles");
                e.Property(r => r.RoleId).HasColumnName("role_id");
                e.Property(r => r.RoleName).HasColumnName("role_name");
            });

            // Tabla "users"
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.Property(u => u.UserId).HasColumnName("user_id");
                e.Property(u => u.Username).HasColumnName("username");
                e.Property(u => u.PasswordHash).HasColumnName("password_hash");
                e.Property(u => u.Email).HasColumnName("email");
                e.Property(u => u.CreatedAt).HasColumnName("created_at");
            });

            // Tabla "user_roles" (Tabla Pivote)
            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("user_roles");
                e.HasKey(ur => new { ur.UserId, ur.RoleId }); // Llave compuesta
                e.Property(ur => ur.UserId).HasColumnName("user_id");
                e.Property(ur => ur.RoleId).HasColumnName("role_id");
                e.Property(ur => ur.AssignedAt).HasColumnName("assigned_at");

                // Relaciones
                e.HasOne(ur => ur.User)
                 .WithMany(u => u.UserRoles)
                 .HasForeignKey(ur => ur.UserId);

                e.HasOne(ur => ur.Role)
                 .WithMany(r => r.UserRoles)
                 .HasForeignKey(ur => ur.RoleId);
            });

            // Tabla "tickets"
            modelBuilder.Entity<Ticket>(e =>
            {
                e.ToTable("tickets");
                e.Property(t => t.TicketId).HasColumnName("ticket_id");
                e.Property(t => t.UserId).HasColumnName("user_id");
                e.Property(t => t.Title).HasColumnName("title");
                e.Property(t => t.Description).HasColumnName("description");
                e.Property(t => t.Status).HasColumnName("status");
                e.Property(t => t.CreatedAt).HasColumnName("created_at");
                e.Property(t => t.ClosedAt).HasColumnName("closed_at");
            });

            // Tabla "responses"
            modelBuilder.Entity<Response>(e =>
            {
                e.ToTable("responses");
                e.Property(r => r.ResponseId).HasColumnName("response_id");
                e.Property(r => r.TicketId).HasColumnName("ticket_id");
                e.Property(r => r.ResponderId).HasColumnName("responder_id");
                e.Property(r => r.Message).HasColumnName("message");
                e.Property(r => r.CreatedAt).HasColumnName("created_at");

                // Relación
                e.HasOne(r => r.Responder)
                 .WithMany(u => u.Responses)
                 .HasForeignKey(r => r.ResponderId);
            });
        }
    }
}
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

            // Configurar la llave primaria compuesta para UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Configurar la relación User -> UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // Configurar la relación Role -> UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Configurar la relación User (Responder) -> Response
            modelBuilder.Entity<Response>()
                .HasOne(r => r.Responder)
                .WithMany(u => u.Responses)
                .HasForeignKey(r => r.ResponderId);
        }
    }
}
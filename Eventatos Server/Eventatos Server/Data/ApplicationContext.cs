using Eventatos_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventatos_Server.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
            .HasKey(u => new { u.UserId, u.RoleId });

            modelBuilder.Entity<UserRole>()
            .HasOne(u => u.User)
            .WithMany(u => u.Roles)
            .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Booking>()
            .HasIndex(b => new { b.UserId, b.EventId }).IsUnique();

            modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Event)
            .WithMany(e => e.Bookings)
            .HasForeignKey(b => b.EventId);            

        }
    }
}

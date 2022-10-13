using ApplicationIdentity2.Entities;
using ApplicationIdentity2.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIdentity2.Context
{
    public class ApplicationIdentityContext : DbContext
    {
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options)
            : base(options)
        { 

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<User>(a => a.HasIndex(a => a.Id).IsUnique());

            modelBuilder.Entity<Role>(a => a.HasIndex(a => a.Id).IsUnique());

            modelBuilder.Entity<Staff>(a => a.HasIndex(a => a.Email).IsUnique());

            modelBuilder.Entity<UserRole>(a =>
            {
                a.HasIndex(a => new { a.UserId, a.RoleId }).IsUnique();
            });
         }
        

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<Staff>? Staffs { get; set; }
    }
}

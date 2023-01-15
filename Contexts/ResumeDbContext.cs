using Microsoft.EntityFrameworkCore;
using ResumeMindX.Domain;

namespace ResumeMindX.Contexts
{
    public class ResumeDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Resume> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasData(
                new Admin()
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin"
                });

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    Username = "user1",
                    Password = "user1"
                });

            base.OnModelCreating(modelBuilder);
        }

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

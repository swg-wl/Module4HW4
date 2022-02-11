using Module4HW3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeesProject { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.HasOne(e => e.OfficeId);
                entity.HasOne(e => e.TiteleId);
                entity.Property("FirstName")
                .HasMaxLength(50)
                .IsRequired();
                entity.Property("LastName")
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => e.EmployeeProjectId);
                entity.HasOne(e => e.EmployeeId);
                entity.HasOne(e => e.ProjectId);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OfficeId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleId);
            });
        }
    }
}

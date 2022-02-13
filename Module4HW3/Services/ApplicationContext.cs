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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.HasOne(e => e.TiteleId);
                entity.HasOne(e => e.OfficeId);
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
                entity.HasOne(e => e.ClientId);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);
            });

            modelBuilder.Entity<Client>()
                .HasData(new Client[] {
                    new Client() { ClientId = 1, FirstName = "1", LastName = "2" },
                    new Client() { ClientId = 2, FirstName = "3", LastName = "4" },
                    new Client() { ClientId = 3, FirstName = "5", LastName = "6" },
                    new Client() { ClientId = 4, FirstName = "7", LastName = "8" },
                    new Client() { ClientId = 5, FirstName = "9", LastName = "0" },
                });

            modelBuilder.Entity<Project>()
                .HasData(new Project[] {
                    new Project() { ProjectId = 1, Name = "1" },
                    new Project() { ProjectId = 2, Name = "2" },
                    new Project() { ProjectId = 3, Name = "3" },
                    new Project() { ProjectId = 4, Name = "4" },
                    new Project() { ProjectId = 5, Name = "5" },
                });
        }
    }
}

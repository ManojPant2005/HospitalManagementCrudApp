using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebServerPractical1.Data.Entities;

namespace WebServerPractical1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.AddEmployeeData(modelBuilder);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }
    }
}

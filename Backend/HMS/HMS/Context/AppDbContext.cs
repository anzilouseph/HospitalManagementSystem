using HMS.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Login> Logins { get; set; }    
        public DbSet<Patient> Patients { get; set; }    

        public DbSet<Department> Departmments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(enitity =>
            {
                enitity.HasKey(e => e.LoginId);
            });
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);
            });
            modelBuilder.Entity<Department>(entity=> entity.HasKey(e=>e.DepartmentId));
        }
    }
}

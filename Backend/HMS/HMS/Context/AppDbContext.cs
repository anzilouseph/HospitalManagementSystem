using HMS.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HMS.Context
{
    public class AppDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext(IDbContextTransaction currentTransaction)
        {
            _currentTransaction = currentTransaction;
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CoreRole> CoreRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }

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
            modelBuilder.Entity<Department>(entity => entity.HasKey(e => e.DepartmentId));
            modelBuilder.Entity<CoreRole>(entity => entity.HasKey(E => E.RoleId));
            modelBuilder.Entity<Employee>(entity=>entity.HasKey(e=>e.EmployeeId));
        }



        public async Task CreateTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _currentTransaction?.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _currentTransaction?.RollbackAsync();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public bool HasActiveTransaction => _currentTransaction != null;
    }

}

using DepartmentReminderSystem.Application.Interfaces;
using DepartmentReminderSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DepartmentReminderSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.SubDepartments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
   new Department { Id = 1, Name = "HR" },
   new Department { Id = 2, Name = "IT" },
   new Department { Id = 3, Name = "Finance" }
);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

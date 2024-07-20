using DepartmentReminderSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DepartmentReminderSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Reminder> Reminders { get; set; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

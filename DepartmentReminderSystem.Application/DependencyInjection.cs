using Microsoft.Extensions.DependencyInjection;

namespace DepartmentReminderSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services
            return services;
        }
    }
}

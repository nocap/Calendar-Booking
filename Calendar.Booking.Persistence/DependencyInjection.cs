using Calendar.Booking.Persistence.Contexts;
using Calendar.Booking.Persistence.Interfaces;
using Calendar.Booking.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Booking.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services) 
        {
            services.AddScoped<LocalDBContext>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}

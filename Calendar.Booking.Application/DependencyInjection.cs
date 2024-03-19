using Calendar.Booking.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Booking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<AddCommand>().AddScoped<BaseCommand, AddCommand>(x => x.GetService<AddCommand>());
            services.AddScoped<DeleteCommand>().AddScoped<BaseCommand, DeleteCommand>(x => x.GetService<DeleteCommand>());
            services.AddScoped<FindCommand>().AddScoped<BaseCommand, FindCommand>(x => x.GetService<FindCommand>());
            services.AddScoped<KeepCommand>().AddScoped<BaseCommand, KeepCommand>(x => x.GetService<KeepCommand>());

            return services;
        }
    }
}

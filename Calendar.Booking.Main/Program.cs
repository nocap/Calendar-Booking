using Calendar.Booking.Application;
using Calendar.Booking.Core;
using Calendar.Booking.Main.Factory;
using Calendar.Booking.Persistence;
using Calendar.Booking.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Calendar.Booking.Main
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0) return;

            using IHost host = CreateHostBuilder(args).Build();

            await CommandExecute(host.Services, args);
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) 
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices((context, services) =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString;
                services.AddApplication()
                .AddPersistence();

                services.AddDbContext<LocalDBContext>(o=> 
                    o.UseSqlServer(connectionString)
                );

                services.AddScoped<ICommandFactory, CommandFactory>();

                
            });

            return builder;                
        }

        private static async Task CommandExecute(IServiceProvider serviceProvider, string[] args)
        {
            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            BookingCommand bookingCommand = (BookingCommand)Enum.Parse(typeof(BookingCommand), args[0], true);

            ICommandFactory factory = provider.GetRequiredService<ICommandFactory>();
            var command = factory.Create(bookingCommand);

            if (!await command.IsValidAsync(args))
            {
                Environment.Exit(1);
                return;
            }
                

            await command.ExecuteAsync(args);

            Environment.Exit(0);
        }
    }
}

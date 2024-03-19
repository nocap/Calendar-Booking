using Calendar.Booking.Application.Commands;
using Calendar.Booking.Core;
using System;

namespace Calendar.Booking.Main.Factory
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseCommand Create(BookingCommand bookingCommand)
        {
            return bookingCommand switch
            {
                BookingCommand.Add => (BaseCommand)_serviceProvider.GetService(typeof(AddCommand)),
                BookingCommand.Delete => (BaseCommand)_serviceProvider.GetService(typeof(DeleteCommand)),
                BookingCommand.Find => (BaseCommand)_serviceProvider.GetService(typeof(FindCommand)),
                BookingCommand.Keep => (BaseCommand)_serviceProvider.GetService(typeof(KeepCommand)),
                _ => throw new ArgumentOutOfRangeException(nameof(bookingCommand), bookingCommand, null)
            };

        }
    }
}

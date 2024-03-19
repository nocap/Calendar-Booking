using Calendar.Booking.Application.Commands;
using Calendar.Booking.Core;

namespace Calendar.Booking.Main.Factory
{
    public interface ICommandFactory
    {
        public BaseCommand Create(BookingCommand bookingCommand);
    }
}

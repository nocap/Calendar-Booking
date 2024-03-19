using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract Task ExecuteAsync(string[] args);
        public abstract Task<bool> IsValidAsync(string[] args);
    }
}

using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public interface ICommand
    {
        public abstract Task ExecuteAsync(string[] args);

        public abstract Task<bool> IsValidAsync(string[] args);
    }
}

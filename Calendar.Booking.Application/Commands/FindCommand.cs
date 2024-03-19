using Calendar.Booking.Application.Helpers;
using Calendar.Booking.Persistence.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public class FindCommand : BaseCommand
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public FindCommand(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public override async Task ExecuteAsync(string[] args)
        {
            var day = DateStringHelper.ToDatetime(args[1], "00:00");
            var firstSlot = DateStringHelper.ToDatetime(args[1], "09:00");

            //There are 16 slots between 9am-5pm
            var remainingSlots = Enumerable.Range(0, 16).Select(x => firstSlot.AddMinutes(30 * x)).Where(x => x > DateTime.Now.AddHours(12)).ToArray();

            var earliestAvailable =  _appointmentRepository.FindFreeTimeSlot(remainingSlots);

            await Console.Out.WriteLineAsync(earliestAvailable.ToString());            
        }

        public override async Task<bool> IsValidAsync(string[] args)
        {
            //TODO: Add more validation, separate common validation to be reusable
            if (args.Length != 2)
            {
                await Console.Out.WriteLineAsync("Invalid FIND syntax");
                return false;
            }

            return true;
        }
    }
}

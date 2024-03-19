using Calendar.Booking.Application.Helpers;
using Calendar.Booking.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public class DeleteCommand : BaseCommand
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteCommand(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public override async Task ExecuteAsync(string[] args)
        {
            var appointmentStart = DateStringHelper.ToDatetime(args[1], args[2]);

            var appointment = _appointmentRepository.FindAppointmentByDateTime(appointmentStart);

            if (appointment == null)
                return;

            await _appointmentRepository.DeleteAppointmentAsync(appointment);
        }

        public override async Task<bool> IsValidAsync(string[] args)
        {
            //TODO: Add more validation, separate common validation to be reusable

            if (args.Length != 3)
            {
                await Console.Out.WriteLineAsync("Invalid DELETE syntax");
                return false;
            }

            var time = args[2].Split(":");

            //Hour
            if (Convert.ToInt16(time[0]) < 9 || Convert.ToInt16(time[0]) > 16)
            {
                await Console.Out.WriteAsync("Invalid Hour");
                return false;
            }


            //Minutes
            if (Convert.ToInt16(time[1]) != 0 && Convert.ToInt16(time[1]) != 30)
            {
                await Console.Out.WriteAsync("Invalid Minute");
                return false;
            }

            return true;
        }
    }
}

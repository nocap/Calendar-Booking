using Calendar.Booking.Application.Helpers;
using Calendar.Booking.Persistence.Interfaces;
using Calendar.Booking.Persistence.Models;
using System;
using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public class KeepCommand : BaseCommand
    {
        private readonly IAppointmentRepository _appointmentRepository;
        
        public KeepCommand(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;            
        }

        public override async Task ExecuteAsync(string[] args)
        {
            var randomDate = DateTime.Now.GetRandomFromToday(7);
            var newDate = DateStringHelper.ToDatetime(randomDate.ToString("dd/MM"), args[1]);

            var appointment = new Appointment {
                StartDateTime = newDate                
            };

            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public override async Task<bool> IsValidAsync(string[] args)
        {            
            //TODO: Add more validation, separate common validation to be reusable

            if (args.Length != 2)
            {
                await Console.Out.WriteLineAsync("Invalid KEEP syntax");
                return false;
            }

            var time = args[1].Split(":");

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

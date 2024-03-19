using Calendar.Booking.Application.Helpers;
using Calendar.Booking.Persistence.Interfaces;
using Calendar.Booking.Persistence.Models;
using System;
using System.Threading.Tasks;

namespace Calendar.Booking.Application.Commands
{
    public class AddCommand : BaseCommand
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AddCommand(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public override async Task ExecuteAsync(string[] args)
        {
            var startDate = DateStringHelper.ToDatetime(args[1], args[2]);

            var appointment = new Appointment
            {
                StartDateTime = startDate                
            };

            await _appointmentRepository.AddAppointmentAsync(appointment);            
        }

        public override async Task<bool> IsValidAsync(string[] args)
        {
            //TODO: Add more validation, separate common validation to be reusable

            if (args.Length != 3)
            {
                await Console.Out.WriteAsync("Invalid ADD syntax");
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

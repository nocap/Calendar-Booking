using Calendar.Booking.Persistence.Contexts;
using Calendar.Booking.Persistence.Interfaces;
using Calendar.Booking.Persistence.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Booking.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly LocalDBContext _context;

        public AppointmentRepository(LocalDBContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            try
            {
                appointment.EndDateTime = appointment.StartDateTime.AddMinutes(30);

                await _context.Appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }


            
            return appointment;
        }

        public async Task DeleteAppointmentAsync(Appointment appointment)
        {            
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public Appointment FindAppointmentByDateTime(DateTime appointmentDate)
        {
            return _context.Appointments.Where(a => a.StartDateTime == appointmentDate).FirstOrDefault();
        }

        public DateTime FindFreeTimeSlot(DateTime[] appointments)
        {
            var booked = _context.Appointments.Where(x => x.StartDateTime.Date == appointments[0].Date)
                                .Select(x => x.StartDateTime);

            return appointments.Except(booked).OrderBy(x => x).FirstOrDefault();

        }
    }
}

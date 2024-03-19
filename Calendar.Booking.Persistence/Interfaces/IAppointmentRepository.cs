using Calendar.Booking.Persistence.Models;
using System;
using System.Threading.Tasks;

namespace Calendar.Booking.Persistence.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
        Appointment FindAppointmentByDateTime(DateTime appointmentDate);
        DateTime FindFreeTimeSlot(DateTime[] appointments);
    }
}

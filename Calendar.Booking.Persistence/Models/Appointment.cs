using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Calendar.Booking.Persistence.Models
{
    public partial class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}


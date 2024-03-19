using Calendar.Booking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Calendar.Booking.Persistence.Contexts
{
    public partial class LocalDBContext : DbContext
    {
        public LocalDBContext()
        {
        }

        public LocalDBContext(DbContextOptions<LocalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

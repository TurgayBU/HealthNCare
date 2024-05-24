using HealthNCare.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthNCare.Models
{
    // Patients1 tablolarını HospitalContext içinde kullanmak için Patients1DbContext'i HospitalContext'e dahil edin
    public class HospitalContext : IdentityDbContext<Patients1>
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppointmentDate> AppointmentDates { get; set; }
        public DbSet<AppointmentTime> AppointmentTimes { get; set; }
        public DbSet<AppointmentRecord> AppointmentRecords { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppointmentRecord>()
                .HasOne(ar => ar.Patients1)
                .WithMany()
                .HasForeignKey(ar => ar.Patients1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentRecord>()
                .Property(ar => ar.HospitalId)
                .IsRequired();

            modelBuilder.Entity<AppointmentRecord>()
                .Property(ar => ar.LocationId)
                .IsRequired();

            modelBuilder.Entity<AppointmentRecord>()
                .Property(ar => ar.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<AppointmentRecord>()
                .Property(ar => ar.DoctorId)
                .IsRequired();
        }
    }
}

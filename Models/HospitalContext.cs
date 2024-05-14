using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;

public class HospitalContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<AppointmentDate> AppointmentDates { get; set; }
    public DbSet<AppointmentTime> AppointmentTimes { get; set; }
   public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
    {
    }


    
}
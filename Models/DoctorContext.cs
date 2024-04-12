using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace HealthNCare.Models{
    public class DoctorContext : DbContext{
       public DbSet<Doctor> Doctors { get; set; }
        public DoctorContext(DbContextOptions<DoctorContext> options ) : base (options){

        }
    }
    public class LocationContext : DbContext{
         public DbSet<Location> Locations { get; set; }

     public LocationContext(DbContextOptions<LocationContext>options):
     base (options){

     }

    }
    public class DepartmentContext : DbContext{
         public DbSet<Department> Departments { get; set; }
         public DepartmentContext(DbContextOptions<DepartmentContext>options):
         base(options){

         }

    }
       
    public class HospitalContext : DbContext{

         public DbSet<Hospital> Hospitals { get; set; }
         public HospitalContext(DbContextOptions<HospitalContext>options):base
         (options){

         }
    }
    public class AppointmentContext : DbContext{

         public DbSet<Appointment> Appointments { get; set; }
         public AppointmentContext(DbContextOptions<AppointmentContext>options): base (options){
          
         }
    }
       
       
}
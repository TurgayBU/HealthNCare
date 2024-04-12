using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace HealthNCare.Models
{
    public class RepositoryContext : DbContext{
        public DbSet<Patient>  Patients{ get ;set; }
        public RepositoryContext (DbContextOptions<RepositoryContext> options)
        : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
            .HasData(
                new Patient {
                    PatientId = 1,
                    FirstName = "John",
                    SecondName= "Doe",
                     Age= 20,
                     Gender= "Male",}
            );
        }
    }
}
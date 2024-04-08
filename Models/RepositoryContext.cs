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
    }
}
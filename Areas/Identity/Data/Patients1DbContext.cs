using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthNCare.Areas.Identity.Data
{
    public class Patients1DbContext : IdentityDbContext<Patients1>
    {
        public Patients1DbContext(DbContextOptions<Patients1DbContext> options)
            : base(options)
        {
        }

        

        
    }
}

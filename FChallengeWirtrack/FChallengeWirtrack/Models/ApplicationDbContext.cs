using Microsoft.EntityFrameworkCore;

namespace FChallengeWirtrack.Models
{
    public class ApplicationDbContext : DbContext
    {

        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        
        public DbSet<Vehiculo> Vehiculo { get; set; }

    }
}

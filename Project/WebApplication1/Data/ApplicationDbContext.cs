using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DBs; // Import your models namespace

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        //internal readonly object Sales;

        public DbSet<Car> Cars { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

     
        }

      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<WebApplication1.Models.DBs.Clients> Clients { get; set; } = default!;
        public DbSet<WebApplication1.Models.DBs.Sales> Sale { get; set; } = default!;
        public DbSet<Sales> Sales { get; set; }

    }
}

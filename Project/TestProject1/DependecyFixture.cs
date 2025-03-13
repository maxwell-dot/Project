using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;

namespace TestProject1
{
    public class DependecyFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DependecyFixture()
        {
            var connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DealershipDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(connectionString));
            serviceCollection.AddDatabaseDeveloperPageExceptionFilter();

            serviceCollection.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
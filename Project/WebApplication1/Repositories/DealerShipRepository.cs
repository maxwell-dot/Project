using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBs;

namespace WebApplication1.Repositories
{
    public class DealerShipRepository
    {
        private readonly ApplicationDbContext _context;

        
        public DealerShipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddClient( Clients client )
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(Clients client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void DeleteClient(Clients client)
        {
            client.IsActive = false;
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public async Task<TestDriveViewModel> GetDataForTestDrive()
        {
            var clients = await _context.Clients.Where(c => c.IsActive).ToListAsync();
            var cars = await _context.Cars.ToListAsync();
            var viewModel = new TestDriveViewModel { Clients = clients, Cars = cars };
            return viewModel;
        }

    }
}

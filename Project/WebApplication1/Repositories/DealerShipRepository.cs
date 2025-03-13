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

        public async Task<List<Clients>> GetClients()
        {
            var clients = await _context.Clients.Where(c => c.IsActive).ToListAsync();
            return clients;
        }

        public async Task<Clients> GetClientById(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            return client;
        }

        public async Task<Car> GetCarById(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            return car;
        }

        public async Task AddSale(Sales sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task AddClient( Clients client )
        {
           await  _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(Clients client)
        {
           _context.Clients.Update(client);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Clients client)
        {
            client.IsActive = false;
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
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

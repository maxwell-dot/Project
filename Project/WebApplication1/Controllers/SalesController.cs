using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.DBs;

namespace WebApplication1.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(Guid id)
        {
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }
        public IActionResult EditClient(Clients client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            return View();
        }

        public async Task<IActionResult> DeleteClient(Clients client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            var clients = await _context.Clients.ToListAsync();
            return View("Index", clients);

        }
    }
}

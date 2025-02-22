using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.DBs;

namespace WebApplication1.Controllers
{
    public class TestDriveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestDriveController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddClient(Clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return View();
        }
        public IActionResult EditClient(Clients client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }

        public async Task<IActionResult> DeleteClient(Clients client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            var clients = await _context.Clients.ToListAsync();
            return View("Index", clients);

        }
    
        public void SelectClient(Guid Id)
        {
            ViewBag.ClientId = Id;

        }

    }
}

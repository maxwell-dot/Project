using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.DBs;

namespace WebApplication1.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddClient(Clients client)
        {
            client.IsActive = true;
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


        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class TestDriveController : Controller
    {
        private readonly DealerShipRepository _repository;

        public TestDriveController(DealerShipRepository repository)
        {
            _repository = repository;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = await _repository.GetDataForTestDrive();
            return View(viewModel);
        }



        [HttpPost]
        public IActionResult AddClient(Clients client)
        {
            _repository.AddClient(client);
            return View();
        }
        public IActionResult EditClient(Clients client)
        {
            _repository.UpdateClient(client);
            return View();
        }

        public async Task<IActionResult> DeleteClient(Clients client)
        {
            _repository.UpdateClient(client);
            //var clients = await _context.Clients.Where(c => c.IsActive).ToListAsync();
            return View("Index");

        }
    
        public void SelectClient(Guid Id)
        {
            ViewBag.ClientId = Id;

        }

    }
}

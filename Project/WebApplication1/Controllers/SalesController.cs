using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DBs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class SalesController : Controller
    {
        //private readonly ApplicationDbContext _context;

        private readonly DealerShipRepository _repository;


        public SalesController(DealerShipRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index(Car car)
        {
            ViewBag.SelectedCar = car;
            var clients = await _repository.GetClients();
            return View(clients);
        }
        public async Task<IActionResult> EditClient(Clients client)
        {
            await _repository.UpdateClient(client);
            return View();
        }

        //public async Task<IActionResult> DeleteClient(Clients client)
        //{
        //    _context.Clients.Remove(client);
        //    _context.SaveChanges();
        //    var clients = await _context.Clients.ToListAsync();
        //    return View("Index", clients);

        //}

        public async Task<IActionResult> DeleteClient(Guid id)
        {

            var client = await _repository.GetClientById(id);

            if (client == null)
            {
                return NotFound(); // Return 404 if client doesn't exist
            }

            client.IsActive = false;

            await _repository.UpdateClient(client);


            // Redirect instead of returning a view
            return RedirectToAction("Index");
        }




        //public async Task<IActionResult> SellCar(Car car, Guid clientId)
        //{
        //    //   return PartialView("_SoldCarPartial");
        //    ViewBag.CarSold = true; 
        //    ViewBag.SelectedCar = car;
        //    var sale = new Sales { IdCar=car.Id, IdClient= clientId , TotalPayment = 60000};
        //    await _context.Sales.AddAsync(sale);
        //   await _context.SaveChangesAsync();
        //    var clients = await _context.Clients.ToListAsync();
        //    return View("Index",  clients);


        //}

        public async Task<IActionResult> SellCar(Guid carId, Guid clientId)
        {
            //var car = await _context.Cars.FindAsync(carId);
            //if (car == null)
            //{
            //    return NotFound("Car not found");
            //}
            Console.WriteLine($"Received carId: {carId}");

            var car = await _repository.GetCarById(carId);
            if (car == null)
            {
                Console.WriteLine($"Car with Id {carId} NOT FOUND in the database!");
                return NotFound("Car not found");
            }

            Console.WriteLine($"Car found: {car.Id} - {car.Name}");


            var sale = new Sales { IdCar = car.Id, IdClient = clientId, TotalPayment = 60000 };
            await _repository.AddSale(sale);

            ViewBag.CarSold = true;
            ViewBag.SelectedCar = car;
            var clients = await _repository.GetClients();
            return View("Index", clients);
        }



    }
}

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
        public async Task<IActionResult> Index(Car car)
        {
            ViewBag.SelectedCar = car;
            var clients = await _context.Clients.Where( c => c.IsActive).ToListAsync();
            return View(clients);
        }
        public IActionResult EditClient(Clients client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
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

            var client = await _context.Clients.FindAsync(id);
            client.IsActive = false;
            if (client == null)
            {
                return NotFound(); // Return 404 if client doesn't exist
            }

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

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

            var car = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == carId);
            if (car == null)
            {
                Console.WriteLine($"Car with Id {carId} NOT FOUND in the database!");
                return NotFound("Car not found");
            }

            Console.WriteLine($"Car found: {car.Id} - {car.Name}");


            var sale = new Sales { IdCar = car.Id, IdClient = clientId, TotalPayment = 60000 };
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();

            ViewBag.CarSold = true;
            ViewBag.SelectedCar = car;
            var clients = await _context.Clients.ToListAsync();
            return View("Index", clients);
        }



    }
}

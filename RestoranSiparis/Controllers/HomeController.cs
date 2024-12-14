using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

namespace RestoranSiparis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert(Musteri musteri)
        {
            
            MusteriRepository musteriRepository = new MusteriRepository("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=restorandb");
            musteriRepository.AddAsync(musteri);
            return View("Index");
        }

        public IActionResult Privacy()  
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

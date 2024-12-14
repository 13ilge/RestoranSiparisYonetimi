using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;
namespace RestoranSiparis.Controllers
{
    

    public class MasaController : Controller
    {
        private readonly MasaRepository _repository;

        public MasaController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new MasaRepository(connectionString);
        }

        // Tüm Masaları Listeleme
        public async Task<IActionResult> Index()
        {
            var masalar = await _repository.GetAllAsync();
            return View(masalar);
        }

        // Yeni Masa Ekleme - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Masa Ekleme - POST
        [HttpPost]
        public async Task<IActionResult> Create(Masa masa)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(masa);
                return RedirectToAction("Index");
            }
            return View(masa);
        }

        // Masa Güncelleme - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var masa = await _repository.GetMasaByIdAsync(id);
            if (masa == null)
            {
                return NotFound();
            }
            return View(masa);
        }

        // Masa Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> Edit(Masa masa)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(masa);
                return RedirectToAction("Index");
            }
            return View(masa);
        }

        // Masa Silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}

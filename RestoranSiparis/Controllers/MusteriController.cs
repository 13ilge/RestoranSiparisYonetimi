using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

namespace RestoranSiparis.Controllers
{
    public class MusteriController : Controller
    {
        private readonly MusteriRepository _repository;

        public MusteriController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new MusteriRepository(connectionString);
        }

        // Tüm Müşterileri Listeleme
        public async Task<IActionResult> Index()
        {
            var musteriler = await _repository.GetAllAsync();
            return View(musteriler);
        }

        // Yeni Müşteri Ekleme - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Müşteri Ekleme - POST
        [HttpPost]
        public async Task<IActionResult> Create(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(musteri);
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // Müşteri Güncelleme - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var musteri = await _repository.GetMusteriByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        // Müşteri Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> Edit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(musteri);
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // Müşteri Silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}

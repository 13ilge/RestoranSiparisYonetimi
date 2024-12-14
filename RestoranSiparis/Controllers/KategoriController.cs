using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;
namespace RestoranSiparis.Controllers
{
    

    public class KategoriController : Controller
    {
        private readonly KategoriRepository _repository;

        public KategoriController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new KategoriRepository(connectionString);
        }

        // Tüm Kategorileri Listeleme
        public async Task<IActionResult> Index()
        {
            var kategoriler = await _repository.GetAllAsync();
            return View(kategoriler);
        }

        // Yeni Kategori Ekleme - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Kategori Ekleme - POST
        [HttpPost]
        public async Task<IActionResult> Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // Kategori Güncelleme - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var kategori = await _repository.GetKategoriByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // Kategori Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // Kategori Silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}

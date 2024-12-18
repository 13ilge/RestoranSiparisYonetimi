using Microsoft.AspNetCore.Mvc;
using Npgsql;
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

        // Silme Onay Sayfası - GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var kategori = await _repository.GetKategoriByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // Kategori Silme - POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Kategoriyi silme işlemi
                await _repository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {
                // Eğer yabancı anahtar hatası alırsak (örneğin kategori bir ürüne bağlıysa)
                TempData["ErrorMessage"] = "Bu kategoriyi silemezsiniz çünkü ona bağlı ürünler bulunmaktadır.";
                return RedirectToAction("Index");
            }
        }
    }

}

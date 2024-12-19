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

        public async Task<IActionResult> Index()
        {
            var kategoriler = await _repository.GetAllAsync();
            return View(kategoriler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {
                TempData["ErrorMessage"] = "Bu kategoriyi silemezsiniz çünkü ona bağlı ürünler bulunmaktadır.";
                return RedirectToAction("Index");
            }
        }
    }

}

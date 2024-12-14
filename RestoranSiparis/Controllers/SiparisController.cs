using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;
namespace RestoranSiparis.Controllers
{
    public class SiparisController : Controller
    {
        private readonly SiparisRepository _repository;

        public SiparisController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new SiparisRepository(connectionString);
        }
        
        // Tüm Siparişleri Listeleme    
        public async Task<IActionResult> Index()
        {
            var siparisler = await _repository.GetAllAsync();
            return View(siparisler);
        }

        // Yeni Sipariş Ekleme - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Sipariş Ekleme - POST
        [HttpPost]
        public async Task<IActionResult> Create(Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(siparis);
                return RedirectToAction("Index");
            }
            return View(siparis);
        }

        // Sipariş Güncelleme - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var siparis = await _repository.GetSiparisByIdAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }
            return View(siparis);
        }

        // Sipariş Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> Edit(Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(siparis);
                return RedirectToAction("Index");
            }
            return View(siparis);
        }

        // Sipariş Silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}

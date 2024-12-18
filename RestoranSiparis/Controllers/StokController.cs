using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class StokController : Controller
{
    private readonly StokRepository _repository;
    UrunlerRepository urunRepository;
    public StokController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new StokRepository(connectionString);
       urunRepository = new UrunlerRepository(connectionString);
    }

    // Tüm Stokları Listeleme
    public async Task<IActionResult> Index()
    {
        var stoklar = await _repository.GetAllAsync();
        return View(stoklar);
    }

    // Yeni Stok Ekleme - GET
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var urunler = await urunRepository.GetAllAsync();
        ViewBag.urunler = urunler;
        return View();
    }

    // Yeni Stok Ekleme - POST
    [HttpPost]
    public async Task<IActionResult> Create(Stok stok)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(stok);
            return RedirectToAction("Index");
        }
        return View(stok);
    }

    // Stok Silme - GET (Onay Sayfası)
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var stok = await _repository.GetStokByIdAsync(id);
        if (stok == null)
        {
            return NotFound();
        }
        return View(stok);
    }

    // Stok Silme - POST (Gerçek Silme İşlemi)
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToAction("Index");
    }

    // Stok Güncelleme - GET
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var stok = await _repository.GetStokByIdAsync(id);
        if (stok == null)
        {
            return NotFound();
        }
        return View(stok);
    }

    // Stok Güncelleme - POST
    [HttpPost]
    public async Task<IActionResult> Edit(Stok stok)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(stok);
            return RedirectToAction("Index");
        }
        return View(stok);
    }
}

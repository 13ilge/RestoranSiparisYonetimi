using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class OdemeController : Controller
{
    private readonly OdemeRepository _repository;

    public OdemeController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new OdemeRepository(connectionString);
    }

    // Tüm Ödemeleri Listeleme
    public async Task<IActionResult> Index()
    {
        var odemeler = await _repository.GetAllAsync();
        return View(odemeler);
    }

    // Yeni Ödeme Ekleme - GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Yeni Ödeme Ekleme - POST
    [HttpPost]
    public async Task<IActionResult> Create(Odeme odeme)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(odeme);
            return RedirectToAction("Index");
        }
        return View(odeme);
    }

    // Ödeme Silme - GET (Onay Sayfası)
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var odeme = await _repository.GetOdemeByIdAsync(id);
        if (odeme == null)
        {
            return NotFound();
        }
        return View(odeme);
    }

    // Ödeme Silme - POST (Gerçek Silme İşlemi)
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        catch (PostgresException ex) when (ex.SqlState == "23503")
        {
            // Kullanıcıya anlamlı bir hata mesajı göster
            TempData["ErrorMessage"] = "Bu ödemeyi silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }

    // Ödeme Güncelleme - GET
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var odeme = await _repository.GetOdemeByIdAsync(id);
        if (odeme == null)
        {
            return NotFound();
        }
        return View(odeme);
    }

    // Ödeme Güncelleme - POST
    [HttpPost]
    public async Task<IActionResult> Edit(Odeme odeme)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(odeme);
            return RedirectToAction("Index");
        }
        return View(odeme);
    }
}

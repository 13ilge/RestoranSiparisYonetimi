using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class GarsonController : Controller
{
    private readonly GarsonRepository _repository;

    public GarsonController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new GarsonRepository(connectionString);
    }

    // Tüm Garsonları Listeleme
    public async Task<IActionResult> Index()
    {
        var garsonlar = await _repository.GetAllAsync();
        return View(garsonlar);
    }

    // Yeni Garson Ekleme - GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Yeni Garson Ekleme - POST
    [HttpPost]
    public async Task<IActionResult> Create(Garson garson)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(garson);
            return RedirectToAction("Index");
        }
        return View(garson);
    }

    // Garson Silme - GET (Onay Sayfası)
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var garson = await _repository.GetGarsonByIdAsync(id);
        if (garson == null)
        {
            return NotFound();
        }
        return View(garson);
    }

    // Garson Silme - POST (Gerçek Silme İşlemi)
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
            // Kullanıcıya anlamlı bir hata mesajı göster
            TempData["ErrorMessage"] = "Bu garsonu silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }

    // Garson Güncelleme - GET
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var garson = await _repository.GetGarsonByIdAsync(id);
        if (garson == null)
        {
            return NotFound();
        }
        return View(garson);
    }

    // Garson Güncelleme - POST
    [HttpPost]
    public async Task<IActionResult> Edit(Garson garson)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(garson);
            return RedirectToAction("Index");
        }
        return View(garson);
    }
}

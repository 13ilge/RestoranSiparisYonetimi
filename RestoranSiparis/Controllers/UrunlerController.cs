using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class UrunlerController : Controller
{
    private readonly UrunlerRepository _repository;

    public UrunlerController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new UrunlerRepository(connectionString);
  
    }

    public async Task<IActionResult> Index()
    {
        var urunler = await _repository.GetAllAsync();
        return View(urunler);
    }

  
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Urunler urun)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(urun);
            return RedirectToAction("Index");
        }
        return View(urun);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var urun = await _repository.GetByIdAsync(id);
        if (urun == null)
        {
            return NotFound();
        }
        return View(urun);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Urunler urun)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(urun);
            return RedirectToAction("Index");
        }
        return View(urun);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var urun = await _repository.GetByIdAsync(id);
        if (urun == null)
        {
            return NotFound();
        }
        return View(urun);
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
            TempData["ErrorMessage"] = "Bu ürünü silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }
}

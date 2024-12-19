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

    public async Task<IActionResult> Index()
    {
        var odemeler = await _repository.GetAllAsync();
        return View(odemeler);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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
            TempData["ErrorMessage"] = "Bu ödemeyi silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }

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

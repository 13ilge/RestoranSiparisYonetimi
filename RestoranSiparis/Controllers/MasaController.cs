using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class MasaController : Controller
{
    private readonly MasaRepository _repository;

    public MasaController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new MasaRepository(connectionString);
    }

    public async Task<IActionResult> Index()
    {
        var masalar = await _repository.GetAllAsync();
        return View(masalar);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Masa masa)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(masa);
            return RedirectToAction("Index");
        }
        return View(masa);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var masa = await _repository.GetMasaByIdAsync(id);
        if (masa == null)
        {
            return NotFound();
        }
        return View(masa);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Masa masa)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(masa);
            return RedirectToAction("Index");
        }
        return View(masa);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var masa = await _repository.GetMasaByIdAsync(id);
        if (masa == null)
        {
            return NotFound();
        }
        return View(masa);
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
            TempData["ErrorMessage"] = "Bu masayı silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }
}

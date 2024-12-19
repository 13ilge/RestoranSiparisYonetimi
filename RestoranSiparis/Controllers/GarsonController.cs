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

    public async Task<IActionResult> Index()
    {
        var garsonlar = await _repository.GetAllAsync();
        return View(garsonlar);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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
            TempData["ErrorMessage"] = "Bu garsonu silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }

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

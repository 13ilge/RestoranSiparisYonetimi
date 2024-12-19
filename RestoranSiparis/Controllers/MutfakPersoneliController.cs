using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class MutfakPersoneliController : Controller
{
    private readonly MutfakPersoneliRepository _repository;

    public MutfakPersoneliController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new MutfakPersoneliRepository(connectionString);
    }

    public async Task<IActionResult> Index()
    {
        var mutfakPersonelleri = await _repository.GetAllAsync();
        return View(mutfakPersonelleri);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MutfakPersoneli personel)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(personel);
            return RedirectToAction("Index");
        }
        return View(personel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var personel = await _repository.GetMutfakPersoneliByIdAsync(id);
        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MutfakPersoneli personel)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(personel);
            return RedirectToAction("Index");
        }
        return View(personel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var personel = await _repository.GetMutfakPersoneliByIdAsync(id);
        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
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
            TempData["ErrorMessage"] = "Bu kasiyeri silemezsiniz çünkü ona bağlı kayıtlar bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }
}

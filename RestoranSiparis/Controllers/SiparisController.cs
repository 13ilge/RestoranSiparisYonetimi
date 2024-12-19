using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class SiparisController : Controller
{
    private readonly SiparisRepository _repository;

    public SiparisController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new SiparisRepository(connectionString);
    }

    public async Task<IActionResult> Index()
    {
        var siparisler = await _repository.GetAllAsync();
        return View(siparisler);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var siparis = await _repository.GetSiparisByIdAsync(id);
        if (siparis == null)
        {
            return NotFound();
        }
        return View(siparis);
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
            TempData["ErrorMessage"] = "Bu kasiyeri silemezsiniz çünkü ona bağlı ödeme kayıtları bulunmaktadır.";
            return RedirectToAction("Index");
        }
    }

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
}

using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

public class KasiyerController : Controller
{
    private readonly KasiyerRepository _repository;

    public KasiyerController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _repository = new KasiyerRepository(connectionString);
    }

    // Tüm Kasiyerleri Listeleme
    public async Task<IActionResult> Index()
    {
        var kasiyerler = await _repository.GetAllAsync();
        return View(kasiyerler);
    }

    // Yeni Kasiyer Ekleme - GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Yeni Kasiyer Ekleme - POST
    [HttpPost]
    public async Task<IActionResult> Create(Kasiyer kasiyer)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(kasiyer);
            return RedirectToAction("Index");
        }
        return View(kasiyer);
    }

    // Kasiyer Güncelleme - GET
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var kasiyer = await _repository.GetKasiyerByIdAsync(id);
        if (kasiyer == null)
        {
            return NotFound();
        }
        return View(kasiyer);
    }

    // Kasiyer Güncelleme - POST
    [HttpPost]
    public async Task<IActionResult> Edit(Kasiyer kasiyer)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(kasiyer);
            return RedirectToAction("Index");
        }
        return View(kasiyer);
    }

    // Kasiyer Silme
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}

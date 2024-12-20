﻿using Microsoft.AspNetCore.Mvc;
using Npgsql;
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

    public async Task<IActionResult> Index()
    {
        var kasiyerler = await _repository.GetAllAsync();
        return View(kasiyerler);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var garson = await _repository.GetKasiyerByIdAsync(id);
        if (garson == null)
        {
            return NotFound();
        }
        return View(garson);
    }

    [HttpPost,ActionName("Delete")]
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
}

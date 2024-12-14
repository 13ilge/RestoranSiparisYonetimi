using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;
using System.Collections.Generic;

namespace RestoranSiparis.Controllers
{
    // Controllers/UrunlerController.cs
   

    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly UrunlerRepository _repository;

        public UrunlerController(UrunlerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Urunler
        [HttpGet]
        public ActionResult<IEnumerable<Urunler>> Get()
        {
            var urunler = _repository.GetAll();
            return Ok(urunler);
        }

        // GET: api/Urunler/5
        [HttpGet("{id}")]
        public ActionResult<Urunler> Get(int id)
        {
            var urun = _repository.GetById(id);
            if (urun == null)
            {
                return NotFound();
            }
            return Ok(urun);
        }

        // POST: api/Urunler
        [HttpPost]
        public ActionResult<Urunler> Post([FromBody] Urunler urun)
        {
            _repository.Add(urun);
            return CreatedAtAction(nameof(Get), new { id = urun.Urun_ID }, urun);
        }

        // PUT: api/Urunler/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Urunler urun)
        {
            var existingUrun = _repository.GetById(id);
            if (existingUrun == null)
            {
                return NotFound();
            }

            urun.Urun_ID = id;
            _repository.Update(urun);
            return NoContent();
        }

        // DELETE: api/Urunler/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUrun = _repository.GetById(id);
            if (existingUrun == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }

}

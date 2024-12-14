using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;
using System.Collections.Generic;

namespace RestoranSiparis.Controllers
{
    // Controllers/StokController.cs
    

    [Route("api/[controller]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly StokRepository _repository;

        public StokController(StokRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Stok
        [HttpGet]
        public ActionResult<IEnumerable<Stok>> Get()
        {
            var stoklar = _repository.GetAll();
            return Ok(stoklar);
        }

        // GET: api/Stok/5
        [HttpGet("{id}")]
        public ActionResult<Stok> Get(int id)
        {
            var stok = _repository.GetById(id);
            if (stok == null)
            {
                return NotFound();
            }
            return Ok(stok);
        }

        // POST: api/Stok
        [HttpPost]
        public ActionResult<Stok> Post([FromBody] Stok stok)
        {
            _repository.Add(stok);
            return CreatedAtAction(nameof(Get), new { id = stok.Stok_ID }, stok);
        }

        // PUT: api/Stok/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stok stok)
        {
            var existingStok = _repository.GetById(id);
            if (existingStok == null)
            {
                return NotFound();
            }

            stok.Stok_ID = id;
            _repository.Update(stok);
            return NoContent();
        }

        // DELETE: api/Stok/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStok = _repository.GetById(id);
            if (existingStok == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }

}

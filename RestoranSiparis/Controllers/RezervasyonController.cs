// Controllers/RezerveController.cs
using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

namespace RestoranSiparis.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private readonly RezervasyonRepository _repository;

        public RezervasyonController(RezervasyonRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Rezervasyon
        [HttpGet]
        public ActionResult<IEnumerable<Rezervasyon>> Get()
        {
            var rezervasyonlar = _repository.GetAll();
            return Ok(rezervasyonlar);
        }

        // GET: api/Rezervasyon/5
        [HttpGet("{id}")]
        public ActionResult<Rezervasyon> Get(int id)
        {
            var rezervasyon = _repository.GetById(id);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            return Ok(rezervasyon);
        }

        // POST: api/Rezervasyon
        [HttpPost]
        public ActionResult<Rezervasyon> Post([FromBody] Rezervasyon rezervasyon)
        {
            _repository.Add(rezervasyon);
            return CreatedAtAction(nameof(Get), new { id = rezervasyon.Rezervasyon_ID }, rezervasyon);
        }

        // PUT: api/Rezervasyon/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Rezervasyon rezervasyon)
        {
            var existingRezervasyon = _repository.GetById(id);
            if (existingRezervasyon == null)
            {
                return NotFound();
            }

            rezervasyon.Rezervasyon_ID = id;
            _repository.Update(rezervasyon);
            return NoContent();
        }

        // DELETE: api/Rezervasyon/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRezervasyon = _repository.GetById(id);
            if (existingRezervasyon == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }

}

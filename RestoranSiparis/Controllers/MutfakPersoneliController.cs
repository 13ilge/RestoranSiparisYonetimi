// Controllers/MutfakPersoneliController.cs
using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

[Route("api/[controller]")]
[ApiController]
public class MutfakPersoneliController : ControllerBase
{
    private readonly MutfakPersoneliRepository _repository;

    public MutfakPersoneliController(MutfakPersoneliRepository repository)
    {
        _repository = repository;
    }

    // GET: api/MutfakPersoneli
    [HttpGet]
    public ActionResult<IEnumerable<MutfakPersoneli>> Get()
    {
        var mutfakPersoneli = _repository.GetAll();
        return Ok(mutfakPersoneli);
    }

    // GET: api/MutfakPersoneli/5
    [HttpGet("{id}")]
    public ActionResult<MutfakPersoneli> Get(int id)
    {
        var mutfakPersoneli = _repository.GetById(id);
        if (mutfakPersoneli == null)
        {
            return NotFound();
        }
        return Ok(mutfakPersoneli);
    }

    // POST: api/MutfakPersoneli
    [HttpPost]
    public ActionResult<MutfakPersoneli> Post([FromBody] MutfakPersoneli mutfakPersoneli)
    {
        _repository.Add(mutfakPersoneli);
        return CreatedAtAction(nameof(Get), new { id = mutfakPersoneli.MutfakP_ID }, mutfakPersoneli);
    }

    // PUT: api/MutfakPersoneli/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] MutfakPersoneli mutfakPersoneli)
    {
        var existingPersonel = _repository.GetById(id);
        if (existingPersonel == null)
        {
            return NotFound();
        }

        mutfakPersoneli.MutfakP_ID = id;
        _repository.Update(mutfakPersoneli);
        return NoContent();
    }

    // DELETE: api/MutfakPersoneli/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingPersonel = _repository.GetById(id);
        if (existingPersonel == null)
        {
            return NotFound();
        }

        _repository.Delete(id);
        return NoContent();
    }
}

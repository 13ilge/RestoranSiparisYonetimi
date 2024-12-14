using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

namespace RestoranSiparis.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SiparisUrunController : ControllerBase
    {
        private readonly SiparisUrunRepository _repository;

        public SiparisUrunController(SiparisUrunRepository repository)
        {
            _repository = repository;
        }

        // GET: api/SiparisUrun
        [HttpGet]
        public ActionResult<IEnumerable<SiparisUrun>> Get()
        {
            var siparisUrunler = _repository.GetAll();
            return Ok(siparisUrunler);
        }
        
        // GET: api/SiparisUrun/5
        [HttpGet("{siparisId}")]
        public ActionResult<IEnumerable<SiparisUrun>> GetBySiparisId(int siparisId)
        {
            var siparisUrunler = _repository.GetBySiparisId(siparisId);
            return Ok(siparisUrunler);
        }

        // POST: api/SiparisUrun
        [HttpPost]
        public ActionResult<SiparisUrun> Post([FromBody] SiparisUrun siparisUrun)
        {
            _repository.Add(siparisUrun);
            return CreatedAtAction(nameof(GetBySiparisId), new { siparisId = siparisUrun.Siparis_ID }, siparisUrun);
        }

        // DELETE: api/SiparisUrun/5/10
        [HttpDelete("{siparisId}/{urunId}")]
        public IActionResult Delete(int siparisId, int urunId)
        {
            _repository.Delete(siparisId, urunId);
            return NoContent();
        }
    }

}

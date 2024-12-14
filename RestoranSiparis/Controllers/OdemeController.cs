using Microsoft.AspNetCore.Mvc;
using RestoranSiparis.Models;
using RestoranSiparis.Repositories;

namespace RestoranSiparis.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        private readonly OdemeRepository _odemeRepository;

        public OdemeController(OdemeRepository odemeRepository)
        {
            _odemeRepository = odemeRepository;
        }

        // Yeni ödeme oluşturma
        [HttpPost]
        public async Task<IActionResult> CreateOdeme([FromBody] Odeme odeme)
        {
            if (odeme == null)
            {
                return BadRequest("Ödeme bilgileri geçersiz.");
            }

            var odemeId = await _odemeRepository.AddOdemeAsync(odeme);

            return CreatedAtAction(nameof(GetOdemeById), new { id = odemeId }, odeme);
        }

        // Ödeme ID ile ödeme bilgilerini alma
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOdemeById(int id)
        {
            var odeme = await _odemeRepository.GetOdemeByIdAsync(id);

            if (odeme == null)
            {
                return NotFound($"Ödeme ID {id} ile eşleşen ödeme bulunamadı.");
            }

            return Ok(odeme);
        }

        // Sipariş ID ile ödeme bilgilerini alma
        [HttpGet("siparis/{siparisId}")]
        public async Task<IActionResult> GetOdemeBySiparisId(int siparisId)
        {
            var odemeler = await _odemeRepository.GetOdemeBySiparisIdAsync(siparisId);

            if (odemeler == null)
            {
                return NotFound($"Sipariş ID {siparisId} ile eşleşen ödemeler bulunamadı.");
            }

            return Ok(odemeler);
        }

        // Ödeme güncelleme
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOdeme(int id, [FromBody] Odeme odeme)
        {
            if (id != odeme.Odeme_ID)
            {
                return BadRequest("Ödeme ID'leri eşleşmiyor.");
            }

            var existingOdeme = await _odemeRepository.GetOdemeByIdAsync(id);

            if (existingOdeme == null)
            {
                return NotFound($"ID {id} ile ödeme bulunamadı.");
            }

            await _odemeRepository.UpdateOdemeAsync(odeme);

            return NoContent();
        }

        // Ödeme silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdeme(int id)
        {
            var existingOdeme = await _odemeRepository.GetOdemeByIdAsync(id);

            if (existingOdeme == null)
            {
                return NotFound($"ID {id} ile ödeme bulunamadı.");
            }

            await _odemeRepository.DeleteOdemeAsync(id);

            return NoContent();
        }
    }

}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using deneme.Models;

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciTblController : ControllerBase
    {
        private readonly KullaniciContext _context;


        public KullaniciTblController(KullaniciContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KullaniciTbl>>> GetKullaniciTbl()
        {
            return await _context.KullaniciTbls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KullaniciTbl>> GetKullaniciTbl(int id)
        {
            var kullaniciTbl = await _context.KullaniciTbls.FindAsync(id);

            if (kullaniciTbl == null)
            {
                return NotFound();
            }

            return kullaniciTbl;
        }

        [HttpPost]
        public async Task<ActionResult<KullaniciTbl>> PostKullaniciTbl(KullaniciTbl kullaniciTbl)
        {
            _context.KullaniciTbls.Add(kullaniciTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKullaniciTbl), new { id = kullaniciTbl.Id }, kullaniciTbl);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKullaniciTbl(int id, KullaniciTbl kullaniciTbl)
        {
            if (id != kullaniciTbl.Id)
            {
                return BadRequest("Id mismatch");
            }

            if (!ModelState.IsValid) // ModelState geçerli mi?
            {
                return BadRequest(ModelState);
            }

            _context.Entry(kullaniciTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullaniciTbl(int id)
        {
            var kullaniciTbl = await _context.KullaniciTbls.FindAsync(id);
            if (kullaniciTbl == null)
            {
                return NotFound();
            }

            _context.KullaniciTbls.Remove(kullaniciTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KullaniciTblExists(int id)
        {
            return _context.KullaniciTbls.Any(e => e.Id == id);
        }
    
}
}

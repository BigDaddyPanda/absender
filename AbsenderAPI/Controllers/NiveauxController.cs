using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Data;
using AbsenderAPI.Models.UniversityModels;

namespace AbsenderAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Niveaux")]
    public class NiveauxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NiveauxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Niveaux
        [HttpGet]
        public IEnumerable<Niveau> GetNiveau()
        {
            return _context.Niveau;
        }

        // GET: api/Niveaux/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNiveau([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var niveau = await _context.Niveau.SingleOrDefaultAsync(m => m.IdNiveau == id);

            if (niveau == null)
            {
                return NotFound();
            }

            return Ok(niveau);
        }

        // PUT: api/Niveaux/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNiveau([FromRoute] int id, [FromBody] Niveau niveau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != niveau.IdNiveau)
            {
                return BadRequest();
            }

            _context.Entry(niveau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NiveauExists(id))
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

        // POST: api/Niveaux
        [HttpPost]
        public async Task<IActionResult> PostNiveau([FromBody] Niveau niveau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Niveau.Add(niveau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNiveau", new { id = niveau.IdNiveau }, niveau);
        }

        // DELETE: api/Niveaux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNiveau([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var niveau = await _context.Niveau.SingleOrDefaultAsync(m => m.IdNiveau == id);
            if (niveau == null)
            {
                return NotFound();
            }

            _context.Niveau.Remove(niveau);
            await _context.SaveChangesAsync();

            return Ok(niveau);
        }

        private bool NiveauExists(int id)
        {
            return _context.Niveau.Any(e => e.IdNiveau == id);
        }
    }
}
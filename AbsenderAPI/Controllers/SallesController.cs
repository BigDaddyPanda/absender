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
    [Route("api/Salles")]
    public class SallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Salles
        [HttpGet]
        public IEnumerable<Salle> GetSalle()
        {
            return _context.Salle;
        }

        // GET: api/Salles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salle = await _context.Salle.SingleOrDefaultAsync(m => m.IdSalle == id);

            if (salle == null)
            {
                return NotFound();
            }

            return Ok(salle);
        }

        // PUT: api/Salles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalle([FromRoute] int id, [FromBody] Salle salle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salle.IdSalle)
            {
                return BadRequest();
            }

            _context.Entry(salle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalleExists(id))
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

        // POST: api/Salles
        [HttpPost]
        public async Task<IActionResult> PostSalle([FromBody] Salle salle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Salle.Add(salle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalle", new { id = salle.IdSalle }, salle);
        }

        // DELETE: api/Salles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salle = await _context.Salle.SingleOrDefaultAsync(m => m.IdSalle == id);
            if (salle == null)
            {
                return NotFound();
            }

            _context.Salle.Remove(salle);
            await _context.SaveChangesAsync();

            return Ok(salle);
        }

        private bool SalleExists(int id)
        {
            return _context.Salle.Any(e => e.IdSalle == id);
        }
    }
}
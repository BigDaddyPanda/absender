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
    [Route("api/TempsSeances")]
    public class TempsSeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TempsSeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TempsSeances
        [HttpGet]
        public IEnumerable<TempsSeance> GetTempsSeance()
        {
            return _context.TempsSeance;
        }

        // GET: api/TempsSeances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTempsSeance([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tempsSeance = await _context.TempsSeance.SingleOrDefaultAsync(m => m.RepresentationHHMM == id);

            if (tempsSeance == null)
            {
                return NotFound();
            }

            return Ok(tempsSeance);
        }

        // PUT: api/TempsSeances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTempsSeance([FromRoute] string id, [FromBody] TempsSeance tempsSeance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tempsSeance.RepresentationHHMM)
            {
                return BadRequest();
            }

            _context.Entry(tempsSeance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempsSeanceExists(id))
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

        // POST: api/TempsSeances
        [HttpPost]
        public async Task<IActionResult> PostTempsSeance([FromBody] TempsSeance tempsSeance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TempsSeance.Add(tempsSeance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTempsSeance", new { id = tempsSeance.RepresentationHHMM }, tempsSeance);
        }

        // DELETE: api/TempsSeances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempsSeance([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tempsSeance = await _context.TempsSeance.SingleOrDefaultAsync(m => m.RepresentationHHMM == id);
            if (tempsSeance == null)
            {
                return NotFound();
            }

            _context.TempsSeance.Remove(tempsSeance);
            await _context.SaveChangesAsync();

            return Ok(tempsSeance);
        }

        private bool TempsSeanceExists(string id)
        {
            return _context.TempsSeance.Any(e => e.RepresentationHHMM == id);
        }
    }
}
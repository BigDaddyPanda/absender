using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models.UniversityModels;
using AbsenderBack.Data;

namespace AbsenderBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Seances
        [HttpGet]
        public IEnumerable<Seance> GetSeance()
        {
            return _context.Seance;
        }

        // GET: api/Seances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seance = await _context.Seance.FindAsync(id);

            if (seance == null)
            {
                return NotFound();
            }

            return Ok(seance);
        }

        // PUT: api/Seances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeance([FromRoute] int id, [FromBody] Seance seance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seance.Id_Seance)
            {
                return BadRequest();
            }

            _context.Entry(seance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(id))
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

        // POST: api/Seances
        [HttpPost]
        public async Task<IActionResult> PostSeance([FromBody] Seance seance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Seance.Add(seance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeance", new { id = seance.Id_Seance }, seance);
        }

        // DELETE: api/Seances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seance = await _context.Seance.FindAsync(id);
            if (seance == null)
            {
                return NotFound();
            }

            _context.Seance.Remove(seance);
            await _context.SaveChangesAsync();

            return Ok(seance);
        }

        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.Id_Seance == id);
        }
    }
}
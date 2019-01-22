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
    public class DiplomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiplomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Diplomes
        [HttpGet]
        public IEnumerable<Diplome> GetDiplome()
        {
            return _context.Diplome;
        }

        // GET: api/Diplomes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiplome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diplome = await _context.Diplome.FindAsync(id);

            if (diplome == null)
            {
                return NotFound();
            }

            return Ok(diplome);
        }

        // PUT: api/Diplomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiplome([FromRoute] int id, [FromBody] Diplome diplome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diplome.Id_Diplome)
            {
                return BadRequest();
            }

            _context.Entry(diplome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomeExists(id))
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

        // POST: api/Diplomes
        [HttpPost]
        public async Task<IActionResult> PostDiplome([FromBody] Diplome diplome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Diplome.Add(diplome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiplome", new { id = diplome.Id_Diplome }, diplome);
        }

        // DELETE: api/Diplomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiplome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diplome = await _context.Diplome.FindAsync(id);
            if (diplome == null)
            {
                return NotFound();
            }

            _context.Diplome.Remove(diplome);
            await _context.SaveChangesAsync();

            return Ok(diplome);
        }

        private bool DiplomeExists(int id)
        {
            return _context.Diplome.Any(e => e.Id_Diplome == id);
        }
    }
}
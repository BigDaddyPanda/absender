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
    public class FilieresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Filieres
        [HttpGet]
        public IEnumerable<Filiere> GetFiliere()
        {
            return _context.Filiere;
        }

        // GET: api/Filieres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFiliere([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filiere = await _context.Filiere.FindAsync(id);

            if (filiere == null)
            {
                return NotFound();
            }

            return Ok(filiere);
        }

        // PUT: api/Filieres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiliere([FromRoute] int id, [FromBody] Filiere filiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filiere.Id_Filiere)
            {
                return BadRequest();
            }

            _context.Entry(filiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereExists(id))
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

        // POST: api/Filieres
        [HttpPost]
        public async Task<IActionResult> PostFiliere([FromBody] Filiere filiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Filiere.Add(filiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiliere", new { id = filiere.Id_Filiere }, filiere);
        }

        // DELETE: api/Filieres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliere([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }

            _context.Filiere.Remove(filiere);
            await _context.SaveChangesAsync();

            return Ok(filiere);
        }

        private bool FiliereExists(int id)
        {
            return _context.Filiere.Any(e => e.Id_Filiere == id);
        }
    }
}
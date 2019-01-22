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
    public class GroupesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Groupes
        [HttpGet]
        public IEnumerable<Groupe> GetGroupe()
        {
            return _context.Groupe;
        }

        // GET: api/Groupes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupe = await _context.Groupe.FindAsync(id);

            if (groupe == null)
            {
                return NotFound();
            }

            return Ok(groupe);
        }

        // PUT: api/Groupes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupe([FromRoute] int id, [FromBody] Groupe groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupe.Id_groupe)
            {
                return BadRequest();
            }

            _context.Entry(groupe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeExists(id))
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

        // POST: api/Groupes
        [HttpPost]
        public async Task<IActionResult> PostGroupe([FromBody] Groupe groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Groupe.Add(groupe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupe", new { id = groupe.Id_groupe }, groupe);
        }

        // DELETE: api/Groupes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupe = await _context.Groupe.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }

            _context.Groupe.Remove(groupe);
            await _context.SaveChangesAsync();

            return Ok(groupe);
        }

        private bool GroupeExists(int id)
        {
            return _context.Groupe.Any(e => e.Id_groupe == id);
        }
    }
}
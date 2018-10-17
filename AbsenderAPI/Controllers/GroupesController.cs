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
    [Route("api/Groupes")]
    public class GroupesController : Controller
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
            return _context.Groupe.Include(group=>group.FiliereGroupe);
        }

        // GET: api/Groupes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupe = await _context.Groupe.SingleOrDefaultAsync(m => m.IdGroupe == id);

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

            if (id != groupe.IdGroupe)
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
            var filiere = _context.Filiere.FirstOrDefault(u => u.IdFiliere.Equals(groupe.IdFiliere));
            groupe.FiliereGroupe = filiere;
            _context.Groupe.Add(groupe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupe", new { id = groupe.IdGroupe }, groupe);
        }

        // DELETE: api/Groupes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupe = await _context.Groupe.SingleOrDefaultAsync(m => m.IdGroupe == id);
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
            return _context.Groupe.Any(e => e.IdGroupe == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models.UniversityModels.Users;
using AbsenderBack.Data;

namespace AbsenderBack.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesseursController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Professeurs
        [HttpGet]
        public IEnumerable<Professeur> GetProfesseur()
        {
            return _context.Professeur;
        }

        // GET: api/Professeurs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesseur([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professeur = await _context.Professeur.FindAsync(id);

            if (professeur == null)
            {
                return NotFound();
            }

            return Ok(professeur);
        }

        // PUT: api/Professeurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesseur([FromRoute] string id, [FromBody] Professeur professeur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professeur.Id_Utilisateur)
            {
                return BadRequest();
            }

            _context.Entry(professeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesseurExists(id))
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

        // POST: api/Professeurs
        [HttpPost]
        public async Task<IActionResult> PostProfesseur([FromBody] Professeur professeur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Professeur.Add(professeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesseur", new { id = professeur.Id_Utilisateur }, professeur);
        }

        // DELETE: api/Professeurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesseur([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professeur = await _context.Professeur.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }

            _context.Professeur.Remove(professeur);
            await _context.SaveChangesAsync();

            return Ok(professeur);
        }

        private bool ProfesseurExists(string id)
        {
            return _context.Professeur.Any(e => e.Id_Utilisateur == id);
        }
    }
}
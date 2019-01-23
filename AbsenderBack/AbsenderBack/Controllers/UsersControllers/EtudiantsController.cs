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
    public class EtudiantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public IEnumerable<Etudiant> GetEtudiant()
        {
            return _context.Etudiant;
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtudiant([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var etudiant = await _context.Etudiant.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return Ok(etudiant);
        }

        // PUT: api/Etudiants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant([FromRoute] string id, [FromBody] Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etudiant.Id_Utilisateur)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiants
        [HttpPost]
        public IActionResult PostEtudiant([FromBody] Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Etudiant.Where(e=>(e.Email == etudiant.Email && e.Hash_Password== etudiant.Hash_Password)); 
            return Ok (new { id = etudiant.Id_Utilisateur });
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiant.Remove(etudiant);
            await _context.SaveChangesAsync();

            return Ok(etudiant);
        }

        private bool EtudiantExists(string id)
        {
            return _context.Etudiant.Any(e => e.Id_Utilisateur == id);
        }  
    }
}
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
    [Route("api/Filieres")]
    public class FilieresController : Controller
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

            var filiere = await _context.Filiere.SingleOrDefaultAsync(m => m.IdFiliere == id);

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

            if (id != filiere.IdFiliere)
            {
                return BadRequest();
            }
            //filiere.AssociationModuleFiliere = new List<FiliereModuleAssociation>();
            //filiere.AssociationModuleFiliere.Add(new FiliereModuleAssociation { IdFiliere = 1, IdModule = 3 });

            _context.Entry(filiere).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
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
        #region sync put
        [HttpPut("sync/{id}")]
        public async void PutFiliereSync([FromRoute] int id, [FromBody] Filiere filiere)
        {
            if (!ModelState.IsValid)
            {
                return ;
            }

            if (id != filiere.IdFiliere)
            {
                return;
            }
            //filiere.AssociationModuleFiliere = new List<FiliereModuleAssociation>();
            //filiere.AssociationModuleFiliere.Add(new FiliereModuleAssociation { IdFiliere = 1, IdModule = 3 });

            filiere.AssociationModuleFiliere.ForEach(e =>
            {
                if (_context.FiliereModuleAssociation.FirstOrDefault(u => u.IdFiliere.Equals(e.IdFiliere) && u.IdModule.Equals(e.IdModule)) == null)
                {
                    _context.FiliereModuleAssociation.Add(new FiliereModuleAssociation
                    {
                        IdModule = e.IdModule,
                        IdFiliere = e.IdFiliere
                    });
                }
            });
            _context.Entry(filiere).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereExists(id))
                {
                    return ;
                }
                else
                {
                    throw;
                }
            }

            return ;
        }
        #endregion
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

            return CreatedAtAction("GetFiliere", new { id = filiere.IdFiliere }, filiere);
        }

        // DELETE: api/Filieres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliere([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filiere = await _context.Filiere.SingleOrDefaultAsync(m => m.IdFiliere == id);
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
            return _context.Filiere.Any(e => e.IdFiliere == id);
        }
    }
}
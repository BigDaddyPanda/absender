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
    [Route("api/FiliereModuleAssociations")]
    public class FiliereModuleAssociationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiliereModuleAssociationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FiliereModuleAssociations
        [HttpGet]
        public IEnumerable<FiliereModuleAssociation> GetFiliereModuleAssociation()
        {
            return _context.FiliereModuleAssociation;
        }

        // GET: api/FiliereModuleAssociations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFiliereModuleAssociation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filiereModuleAssociation = await _context.FiliereModuleAssociation.SingleOrDefaultAsync(m => m.IdFiliere == id);

            if (filiereModuleAssociation == null)
            {
                return NotFound();
            }

            return Ok(filiereModuleAssociation);
        }

        // PUT: api/FiliereModuleAssociations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiliereModuleAssociation([FromRoute] int id, [FromBody] FiliereModuleAssociation filiereModuleAssociation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filiereModuleAssociation.IdFiliere)
            {
                return BadRequest();
            }

            _context.Entry(filiereModuleAssociation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereModuleAssociationExists(id))
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

        // POST: api/FiliereModuleAssociations
        [HttpPost]
        public async Task<IActionResult> PostFiliereModuleAssociation([FromBody] FiliereModuleAssociation filiereModuleAssociation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FiliereModuleAssociation.Add(filiereModuleAssociation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FiliereModuleAssociationExists(filiereModuleAssociation.IdFiliere))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFiliereModuleAssociation", new { id = filiereModuleAssociation.IdFiliere }, filiereModuleAssociation);
        }

        // DELETE: api/FiliereModuleAssociations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliereModuleAssociation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filiereModuleAssociation = await _context.FiliereModuleAssociation.SingleOrDefaultAsync(m => m.IdFiliere == id);
            if (filiereModuleAssociation == null)
            {
                return NotFound();
            }

            _context.FiliereModuleAssociation.Remove(filiereModuleAssociation);
            await _context.SaveChangesAsync();

            return Ok(filiereModuleAssociation);
        }

        private bool FiliereModuleAssociationExists(int id)
        {
            return _context.FiliereModuleAssociation.Any(e => e.IdFiliere == id);
        }
    }
}
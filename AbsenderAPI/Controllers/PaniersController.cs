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
    [Route("api/Paniers")]
    public class PaniersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Paniers
        [HttpGet]
        public IEnumerable<Panier> GetPanier()
        {
            return _context.Panier;
        }

        // GET: api/Paniers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPanier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var panier = await _context.Panier.SingleOrDefaultAsync(m => m.IdPanier == id);

            if (panier == null)
            {
                return NotFound();
            }

            return Ok(panier);
        }

        // PUT: api/Paniers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanier([FromRoute] int id, [FromBody] Panier panier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != panier.IdPanier)
            {
                return BadRequest();
            }

            _context.Entry(panier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanierExists(id))
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

        // POST: api/Paniers
        [HttpPost]
        public async Task<IActionResult> PostPanier([FromBody] Panier panier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Panier.Add(panier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanier", new { id = panier.IdPanier }, panier);
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var panier = await _context.Panier.SingleOrDefaultAsync(m => m.IdPanier == id);
            if (panier == null)
            {
                return NotFound();
            }

            _context.Panier.Remove(panier);
            await _context.SaveChangesAsync();

            return Ok(panier);
        }

        private bool PanierExists(int id)
        {
            return _context.Panier.Any(e => e.IdPanier == id);
        }
    }
}
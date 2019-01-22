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
    public class AbsencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Absences
        [HttpGet]
        public IEnumerable<Absence> GetAbsence()
        {
            return _context.Absence;
        }

        // GET: api/Absences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var absence = await _context.Absence.FindAsync(id);

            if (absence == null)
            {
                return NotFound();
            }

            return Ok(absence);
        }

        // PUT: api/Absences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbsence([FromRoute] int id, [FromBody] Absence absence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != absence.Id_Absence)
            {
                return BadRequest();
            }

            _context.Entry(absence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceExists(id))
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

        // POST: api/Absences
        [HttpPost]
        public async Task<IActionResult> PostAbsence([FromBody] Absence absence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Absence.Add(absence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbsence", new { id = absence.Id_Absence }, absence);
        }

        // DELETE: api/Absences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }

            _context.Absence.Remove(absence);
            await _context.SaveChangesAsync();

            return Ok(absence);
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absence.Any(e => e.Id_Absence == id);
        }
    }
}
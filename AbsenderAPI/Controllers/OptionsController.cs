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
    [Route("api/Options")]
    public class OptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [HttpGet]
        public IEnumerable<Option> GetOption()
        {
            return _context.Option;
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var option = await _context.Option.SingleOrDefaultAsync(m => m.IdOption == id);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // PUT: api/Options/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption([FromRoute] int id, [FromBody] Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.IdOption)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        [HttpPost]
        public async Task<IActionResult> PostOption([FromBody] Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Option.Add(option);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = option.IdOption }, option);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var option = await _context.Option.SingleOrDefaultAsync(m => m.IdOption == id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Option.Remove(option);
            await _context.SaveChangesAsync();

            return Ok(option);
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.IdOption == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models.UniversityModels;
using AbsenderBack.Data;

namespace AbsenderBack.Controllers.UsersControllers
{
    public class DiplomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiplomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diplomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diplome.ToListAsync());
        }

        // GET: Diplomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplome = await _context.Diplome
                .FirstOrDefaultAsync(m => m.Id_Diplome == id);
            if (diplome == null)
            {
                return NotFound();
            }

            return View(diplome);
        }

        // GET: Diplomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diplomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Diplome,Designation_Orientation,Designation_Formation,Type_Cours")] Diplome diplome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diplome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diplome);
        }

        // GET: Diplomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplome = await _context.Diplome.FindAsync(id);
            if (diplome == null)
            {
                return NotFound();
            }
            return View(diplome);
        }

        // POST: Diplomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Diplome,Designation_Orientation,Designation_Formation,Type_Cours")] Diplome diplome)
        {
            if (id != diplome.Id_Diplome)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diplome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiplomeExists(diplome.Id_Diplome))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diplome);
        }

        // GET: Diplomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplome = await _context.Diplome
                .FirstOrDefaultAsync(m => m.Id_Diplome == id);
            if (diplome == null)
            {
                return NotFound();
            }

            return View(diplome);
        }

        // POST: Diplomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diplome = await _context.Diplome.FindAsync(id);
            _context.Diplome.Remove(diplome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiplomeExists(int id)
        {
            return _context.Diplome.Any(e => e.Id_Diplome == id);
        }
    }
}

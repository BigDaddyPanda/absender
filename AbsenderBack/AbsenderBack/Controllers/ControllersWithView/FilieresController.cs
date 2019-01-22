using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models.UniversityModels;
using AbsenderBack.Data;

namespace AbsenderBack.Controllers.ControllersWithView
{
    public class FilieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filieres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Filiere.Include(f => f.Ref_Diplome);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Filieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .Include(f => f.Ref_Diplome)
                .FirstOrDefaultAsync(m => m.Id_Filiere == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filieres/Create
        public IActionResult Create()
        {
            ViewData["Fk_Diplome"] = new SelectList(_context.Diplome, "Id_Diplome", "Id_Diplome");
            return View();
        }

        // POST: Filieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Filiere,Designation_Niveau,Designation_Filiere,Designation_Option,Fk_Diplome")] Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Diplome"] = new SelectList(_context.Diplome, "Id_Diplome", "Id_Diplome", filiere.Fk_Diplome);
            return View(filiere);
        }

        // GET: Filieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            ViewData["Fk_Diplome"] = new SelectList(_context.Diplome, "Id_Diplome", "Id_Diplome", filiere.Fk_Diplome);
            return View(filiere);
        }

        // POST: Filieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Filiere,Designation_Niveau,Designation_Filiere,Designation_Option,Fk_Diplome")] Filiere filiere)
        {
            if (id != filiere.Id_Filiere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.Id_Filiere))
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
            ViewData["Fk_Diplome"] = new SelectList(_context.Diplome, "Id_Diplome", "Id_Diplome", filiere.Fk_Diplome);
            return View(filiere);
        }

        // GET: Filieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .Include(f => f.Ref_Diplome)
                .FirstOrDefaultAsync(m => m.Id_Filiere == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiere = await _context.Filiere.FindAsync(id);
            _context.Filiere.Remove(filiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
            return _context.Filiere.Any(e => e.Id_Filiere == id);
        }
    }
}

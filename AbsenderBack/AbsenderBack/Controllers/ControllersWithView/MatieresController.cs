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
    public class MatieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matieres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matiere.Include(m => m.Ref_Module);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere
                .Include(m => m.Ref_Module)
                .FirstOrDefaultAsync(m => m.Id_Matiere == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matieres/Create
        public IActionResult Create()
        {
            ViewData["Fk_Module"] = new SelectList(_context.Module, "Id_Module", "Id_Module");
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Matiere,Designation_Matiere,Coefficient,Limite_Absence,Fk_Module")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Module"] = new SelectList(_context.Module, "Id_Module", "Id_Module", matiere.Fk_Module);
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            ViewData["Fk_Module"] = new SelectList(_context.Module, "Id_Module", "Id_Module", matiere.Fk_Module);
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Matiere,Designation_Matiere,Coefficient,Limite_Absence,Fk_Module")] Matiere matiere)
        {
            if (id != matiere.Id_Matiere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.Id_Matiere))
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
            ViewData["Fk_Module"] = new SelectList(_context.Module, "Id_Module", "Id_Module", matiere.Fk_Module);
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiere
                .Include(m => m.Ref_Module)
                .FirstOrDefaultAsync(m => m.Id_Matiere == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matiere = await _context.Matiere.FindAsync(id);
            _context.Matiere.Remove(matiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(int id)
        {
            return _context.Matiere.Any(e => e.Id_Matiere == id);
        }
    }
}

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
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Absence.Include(a => a.Ref_Etudiant).Include(a => a.Ref_Seance);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Ref_Etudiant)
                .Include(a => a.Ref_Seance)
                .FirstOrDefaultAsync(m => m.Id_Absence == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            ViewData["Fk_Etudiant"] = new SelectList(_context.Etudiant, "Id_Utilisateur", "Id_Utilisateur");
            ViewData["Fk_Seance"] = new SelectList(_context.Seance, "Id_Seance", "Id_Seance");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Absence,Justificatif,Date_sauvegarde,EstAbsent,Fk_Etudiant,Fk_Seance")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Etudiant"] = new SelectList(_context.Etudiant, "Id_Utilisateur", "Id_Utilisateur", absence.Fk_Etudiant);
            ViewData["Fk_Seance"] = new SelectList(_context.Seance, "Id_Seance", "Id_Seance", absence.Fk_Seance);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            ViewData["Fk_Etudiant"] = new SelectList(_context.Etudiant, "Id_Utilisateur", "Id_Utilisateur", absence.Fk_Etudiant);
            ViewData["Fk_Seance"] = new SelectList(_context.Seance, "Id_Seance", "Id_Seance", absence.Fk_Seance);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Absence,Justificatif,Date_sauvegarde,EstAbsent,Fk_Etudiant,Fk_Seance")] Absence absence)
        {
            if (id != absence.Id_Absence)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.Id_Absence))
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
            ViewData["Fk_Etudiant"] = new SelectList(_context.Etudiant, "Id_Utilisateur", "Id_Utilisateur", absence.Fk_Etudiant);
            ViewData["Fk_Seance"] = new SelectList(_context.Seance, "Id_Seance", "Id_Seance", absence.Fk_Seance);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Ref_Etudiant)
                .Include(a => a.Ref_Seance)
                .FirstOrDefaultAsync(m => m.Id_Absence == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absence = await _context.Absence.FindAsync(id);
            _context.Absence.Remove(absence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absence.Any(e => e.Id_Absence == id);
        }
    }
}

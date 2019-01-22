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
    public class SeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seance.Include(s => s.Ref_Groupe).Include(s => s.Ref_Matiere).Include(s => s.Ref_Professeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance
                .Include(s => s.Ref_Groupe)
                .Include(s => s.Ref_Matiere)
                .Include(s => s.Ref_Professeur)
                .FirstOrDefaultAsync(m => m.Id_Seance == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // GET: Seances/Create
        public IActionResult Create()
        {
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe");
            ViewData["Fk_Matiere"] = new SelectList(_context.Matiere, "Id_Matiere", "Id_Matiere");
            ViewData["Fk_Professeur"] = new SelectList(_context.Professeur, "Id_Utilisateur", "Id_Utilisateur");
            return View();
        }

        // POST: Seances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Seance,Start_Time,End_Time,Fk_Matiere,Fk_Professeur,Fk_Groupe")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", seance.Fk_Groupe);
            ViewData["Fk_Matiere"] = new SelectList(_context.Matiere, "Id_Matiere", "Id_Matiere", seance.Fk_Matiere);
            ViewData["Fk_Professeur"] = new SelectList(_context.Professeur, "Id_Utilisateur", "Id_Utilisateur", seance.Fk_Professeur);
            return View(seance);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance.FindAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", seance.Fk_Groupe);
            ViewData["Fk_Matiere"] = new SelectList(_context.Matiere, "Id_Matiere", "Id_Matiere", seance.Fk_Matiere);
            ViewData["Fk_Professeur"] = new SelectList(_context.Professeur, "Id_Utilisateur", "Id_Utilisateur", seance.Fk_Professeur);
            return View(seance);
        }

        // POST: Seances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Seance,Start_Time,End_Time,Fk_Matiere,Fk_Professeur,Fk_Groupe")] Seance seance)
        {
            if (id != seance.Id_Seance)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.Id_Seance))
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
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", seance.Fk_Groupe);
            ViewData["Fk_Matiere"] = new SelectList(_context.Matiere, "Id_Matiere", "Id_Matiere", seance.Fk_Matiere);
            ViewData["Fk_Professeur"] = new SelectList(_context.Professeur, "Id_Utilisateur", "Id_Utilisateur", seance.Fk_Professeur);
            return View(seance);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seance
                .Include(s => s.Ref_Groupe)
                .Include(s => s.Ref_Matiere)
                .Include(s => s.Ref_Professeur)
                .FirstOrDefaultAsync(m => m.Id_Seance == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seance = await _context.Seance.FindAsync(id);
            _context.Seance.Remove(seance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.Id_Seance == id);
        }
    }
}

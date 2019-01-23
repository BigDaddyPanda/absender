using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models.UniversityModels.Users;
using AbsenderBack.Data;

namespace AbsenderBack.Controllers.ControllersWithView
{
    public class EtudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Etudiant.Include(e => e.Ref_Groupe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .Include(e => e.Ref_Groupe)
                .FirstOrDefaultAsync(m => m.Id_Utilisateur == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe");
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactParent,Fk_Groupe,Id_Utilisateur,IdNational,IdUniversitaire,NomPrenom,PhotoProfil,Fichier_Profil,Email,Standarized_Email,Hash_Password,Email_Confirm,Connect")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", etudiant.Fk_Groupe);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", etudiant.Fk_Groupe);
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContactParent,Fk_Groupe,Id_Utilisateur,IdNational,IdUniversitaire,NomPrenom,PhotoProfil,Fichier_Profil,Email,Standarized_Email,Hash_Password,Email_Confirm,Connect")] Etudiant etudiant)
        {
            if (id != etudiant.Id_Utilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id_Utilisateur))
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
            ViewData["Fk_Groupe"] = new SelectList(_context.Groupe, "Id_groupe", "Id_groupe", etudiant.Fk_Groupe);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .Include(e => e.Ref_Groupe)
                .FirstOrDefaultAsync(m => m.Id_Utilisateur == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var etudiant = await _context.Etudiant.FindAsync(id);
            _context.Etudiant.Remove(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(string id)
        {
            return _context.Etudiant.Any(e => e.Id_Utilisateur == id);
        }
    }
}

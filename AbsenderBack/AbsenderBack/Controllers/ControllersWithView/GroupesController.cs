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
    public class GroupesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groupes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groupe.Include(g => g.Ref_Filiere);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Groupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe
                .Include(g => g.Ref_Filiere)
                .FirstOrDefaultAsync(m => m.Id_groupe == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // GET: Groupes/Create
        public IActionResult Create()
        {
            ViewData["Fk_Filiere"] = new SelectList(_context.Filiere, "Id_Filiere", "Id_Filiere");
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_groupe,Designation_groupe,Fk_Filiere")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fk_Filiere"] = new SelectList(_context.Filiere, "Id_Filiere", "Id_Filiere", groupe.Fk_Filiere);
            return View(groupe);
        }

        // GET: Groupes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            ViewData["Fk_Filiere"] = new SelectList(_context.Filiere, "Id_Filiere", "Id_Filiere", groupe.Fk_Filiere);
            return View(groupe);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_groupe,Designation_groupe,Fk_Filiere")] Groupe groupe)
        {
            if (id != groupe.Id_groupe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupeExists(groupe.Id_groupe))
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
            ViewData["Fk_Filiere"] = new SelectList(_context.Filiere, "Id_Filiere", "Id_Filiere", groupe.Fk_Filiere);
            return View(groupe);
        }

        // GET: Groupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe
                .Include(g => g.Ref_Filiere)
                .FirstOrDefaultAsync(m => m.Id_groupe == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupe = await _context.Groupe.FindAsync(id);
            _context.Groupe.Remove(groupe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupeExists(int id)
        {
            return _context.Groupe.Any(e => e.Id_groupe == id);
        }
    }
}

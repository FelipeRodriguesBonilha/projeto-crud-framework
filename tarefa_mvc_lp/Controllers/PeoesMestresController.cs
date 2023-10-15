using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tarefa_mvc_lp.Models;

namespace tarefa_mvc_lp.Controllers
{
    public class PeoesMestresController : Controller
    {
        private readonly Contexto _context;

        public PeoesMestresController(Contexto context)
        {
            _context = context;
        }

        // GET: PeoesMestres
        public async Task<IActionResult> Index()
        {
              return View(await _context.peoesMestres.ToListAsync());
        }

        // GET: PeoesMestres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.peoesMestres == null)
            {
                return NotFound();
            }

            var peaoMestre = await _context.peoesMestres
                .FirstOrDefaultAsync(m => m.id == id);
            if (peaoMestre == null)
            {
                return NotFound();
            }

            return View(peaoMestre);
        }

        // GET: PeoesMestres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeoesMestres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,telefone,email,data_nasc,quantidade")] PeaoMestre peaoMestre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peaoMestre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peaoMestre);
        }

        // GET: PeoesMestres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.peoesMestres == null)
            {
                return NotFound();
            }

            var peaoMestre = await _context.peoesMestres.FindAsync(id);
            if (peaoMestre == null)
            {
                return NotFound();
            }
            return View(peaoMestre);
        }

        // POST: PeoesMestres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,telefone,email,data_nasc,quantidade")] PeaoMestre peaoMestre)
        {
            if (id != peaoMestre.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peaoMestre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeaoMestreExists(peaoMestre.id))
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
            return View(peaoMestre);
        }

        // GET: PeoesMestres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.peoesMestres == null)
            {
                return NotFound();
            }

            var peaoMestre = await _context.peoesMestres
                .FirstOrDefaultAsync(m => m.id == id);
            if (peaoMestre == null)
            {
                return NotFound();
            }

            return View(peaoMestre);
        }

        // POST: PeoesMestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.peoesMestres == null)
            {
                return Problem("Entity set 'Contexto.peoesMestres'  is null.");
            }
            var peaoMestre = await _context.peoesMestres.FindAsync(id);
            if (peaoMestre != null)
            {
                _context.peoesMestres.Remove(peaoMestre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeaoMestreExists(int id)
        {
          return _context.peoesMestres.Any(e => e.id == id);
        }
    }
}

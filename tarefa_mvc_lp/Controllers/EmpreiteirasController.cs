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
    public class EmpreiteirasController : Controller
    {
        private readonly Contexto _context;

        public EmpreiteirasController(Contexto context)
        {
            _context = context;
        }

        // GET: Empreiteiras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Empreiteiras.ToListAsync());
        }

        // GET: Empreiteiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empreiteiras == null)
            {
                return NotFound();
            }

            var empreiteira = await _context.Empreiteiras
                .FirstOrDefaultAsync(m => m.id == id);
            if (empreiteira == null)
            {
                return NotFound();
            }

            return View(empreiteira);
        }

        // GET: Empreiteiras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empreiteiras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cnpj,descricao,endereco,telefone")] Empreiteira empreiteira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreiteira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empreiteira);
        }

        // GET: Empreiteiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empreiteiras == null)
            {
                return NotFound();
            }

            var empreiteira = await _context.Empreiteiras.FindAsync(id);
            if (empreiteira == null)
            {
                return NotFound();
            }
            return View(empreiteira);
        }

        // POST: Empreiteiras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cnpj,descricao,endereco,telefone")] Empreiteira empreiteira)
        {
            if (id != empreiteira.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreiteira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreiteiraExists(empreiteira.id))
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
            return View(empreiteira);
        }

        // GET: Empreiteiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empreiteiras == null)
            {
                return NotFound();
            }

            var empreiteira = await _context.Empreiteiras
                .FirstOrDefaultAsync(m => m.id == id);
            if (empreiteira == null)
            {
                return NotFound();
            }

            return View(empreiteira);
        }

        // POST: Empreiteiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empreiteiras == null)
            {
                return Problem("Entity set 'Contexto.Empreiteiras'  is null.");
            }
            var empreiteira = await _context.Empreiteiras.FindAsync(id);
            if (empreiteira != null)
            {
                _context.Empreiteiras.Remove(empreiteira);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreiteiraExists(int id)
        {
          return _context.Empreiteiras.Any(e => e.id == id);
        }
    }
}

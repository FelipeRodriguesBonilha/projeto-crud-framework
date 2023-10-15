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
    public class ObrasController : Controller
    {
        private readonly Contexto _context;

        public ObrasController(Contexto context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Obras.Include(o => o.empreiteira).Include(o => o.peao).Include(o => o.peaoMestre);
            return View(await contexto.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Obras == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.empreiteira)
                .Include(o => o.peao)
                .Include(o => o.peaoMestre)
                .FirstOrDefaultAsync(m => m.id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            ViewData["empreiteiraID"] = new SelectList(_context.Empreiteiras, "id", "descricao");
            ViewData["peaoID"] = new SelectList(_context.Peoes, "id", "nome");
            ViewData["peaoMestreID"] = new SelectList(_context.peoesMestres, "id", "nome");
            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,peaoID,peaoMestreID,empreiteiraID,valorHora,status")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obra);

                var p = _context.peoesMestres.Find(obra.peaoMestreID);

                if (p != null)
                {
                    p.adicionaQuantidade();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["empreiteiraID"] = new SelectList(_context.Empreiteiras, "id", "descricao", obra.empreiteiraID);
            ViewData["peaoID"] = new SelectList(_context.Peoes, "id", "nome", obra.peaoID);
            ViewData["peaoMestreID"] = new SelectList(_context.peoesMestres, "id", "nome", obra.peaoMestreID);
            return View(obra);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Obras == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["empreiteiraID"] = new SelectList(_context.Empreiteiras, "id", "descricao", obra.empreiteiraID);
            ViewData["peaoID"] = new SelectList(_context.Peoes, "id", "nome", obra.peaoID);
            ViewData["peaoMestreID"] = new SelectList(_context.peoesMestres, "id", "nome", obra.peaoMestreID);
            return View(obra);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,peaoID,peaoMestreID,empreiteiraID,valorHora,status")] Obra obra)
        {
            if (id != obra.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.id))
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
            ViewData["empreiteiraID"] = new SelectList(_context.Empreiteiras, "id", "descricao", obra.empreiteiraID);
            ViewData["peaoID"] = new SelectList(_context.Peoes, "id", "nome", obra.peaoID);
            ViewData["peaoMestreID"] = new SelectList(_context.peoesMestres, "id", "nome", obra.peaoMestreID);
            return View(obra);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Obras == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.empreiteira)
                .Include(o => o.peao)
                .Include(o => o.peaoMestre)
                .FirstOrDefaultAsync(m => m.id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Obras == null)
            {
                return Problem("Entity set 'Contexto.Obras'  is null.");
            }
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
          return _context.Obras.Any(e => e.id == id);
        }
    }
}

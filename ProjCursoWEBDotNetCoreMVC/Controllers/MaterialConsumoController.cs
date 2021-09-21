using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoWebCoreMVC.Models;
using ProjCursoWEBDotNetCoreMVC.Data;

namespace ProjCursoWEBDotNetCoreMVC.Controllers
{
    public class MaterialConsumoController : Controller
    {
        private readonly ProjCursoWEBDotNetCoreMVCContext _context;

        public MaterialConsumoController(ProjCursoWEBDotNetCoreMVCContext context)
        {
            _context = context;
        }

        // GET: MaterialConsumos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialConsumo.ToListAsync());
        }

        // GET: MaterialConsumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialConsumo = await _context.MaterialConsumo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialConsumo == null)
            {
                return NotFound();
            }

            return View(materialConsumo);
        }

        // GET: MaterialConsumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialConsumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,QtdProduto")] MaterialConsumo materialConsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialConsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialConsumo);
        }

        // GET: MaterialConsumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialConsumo = await _context.MaterialConsumo.FindAsync(id);
            if (materialConsumo == null)
            {
                return NotFound();
            }
            return View(materialConsumo);
        }

        // POST: MaterialConsumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,QtdProduto")] MaterialConsumo materialConsumo)
        {
            if (id != materialConsumo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialConsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialConsumoExists(materialConsumo.Id))
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
            return View(materialConsumo);
        }

        // GET: MaterialConsumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialConsumo = await _context.MaterialConsumo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialConsumo == null)
            {
                return NotFound();
            }

            return View(materialConsumo);
        }

        // POST: MaterialConsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialConsumo = await _context.MaterialConsumo.FindAsync(id);
            _context.MaterialConsumo.Remove(materialConsumo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialConsumoExists(int id)
        {
            return _context.MaterialConsumo.Any(e => e.Id == id);
        }
    }
}

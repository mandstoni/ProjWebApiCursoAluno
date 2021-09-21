using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoWebCoreMVC.Models;
using ProjCursoAPIDotNetCoreMVC.Data;

namespace ProjCursoAPIDotNetCoreMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialConsumosController : ControllerBase
    {
        private readonly ProjCursoAPIDotNetCoreMVCContext _context;

        public MaterialConsumosController(ProjCursoAPIDotNetCoreMVCContext context)
        {
            _context = context;
        }

        // GET: api/MaterialConsumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialConsumo>>> GetMaterialConsumo()
        {
            return await _context.MaterialConsumo.ToListAsync();
        }

        // GET: api/MaterialConsumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialConsumo>> GetMaterialConsumo(int id)
        {
            var MaterialConsumo = await _context.MaterialConsumo.FindAsync(id);

            if (MaterialConsumo == null)
            {
                return NotFound();
            }

            return MaterialConsumo;
        }

        // PUT: api/MaterialConsumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialConsumo(int id, MaterialConsumo MaterialConsumo)
        {
            if (id != MaterialConsumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(MaterialConsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialConsumoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MaterialConsumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialConsumo>> PostMaterialConsumo(MaterialConsumo MaterialConsumo)
        {
            _context.MaterialConsumo.Add(MaterialConsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialConsumo", new { id = MaterialConsumo.Id }, MaterialConsumo);
        }

        // DELETE: api/MaterialConsumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialConsumo(int id)
        {
            var MaterialConsumo = await _context.MaterialConsumo.FindAsync(id);
            if (MaterialConsumo == null)
            {
                return NotFound();
            }

            _context.MaterialConsumo.Remove(MaterialConsumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialConsumoExists(int id)
        {
            return _context.MaterialConsumo.Any(e => e.Id == id);
        }
    }
}

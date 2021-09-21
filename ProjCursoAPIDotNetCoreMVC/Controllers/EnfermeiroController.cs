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
    public class EnfermeiroController : ControllerBase
    {
        private readonly ProjCursoAPIDotNetCoreMVCContext _context;

        public EnfermeiroController(ProjCursoAPIDotNetCoreMVCContext context)
        {
            _context = context;
        }

        // GET: api/Enfermeiro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfermeiro>>> GetEnfermeiro()
        {
            return await _context.Enfermeiro.ToListAsync();
        }

        // GET: api/Enfermeiro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermeiro>> GetEnfermeiro(int id)
        {
            var Enfermeiro = await _context.Enfermeiro.FindAsync(id);

            if (Enfermeiro == null)
            {
                return NotFound();
            }

            return Enfermeiro;
        }

        // PUT: api/Enfermeiro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermeiro(int id, Enfermeiro Enfermeiro)
        {
            if (id != Enfermeiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(Enfermeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermeiroExists(id))
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

        // POST: api/Enfermeiro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enfermeiro>> PostEnfermeiro(Enfermeiro Enfermeiro)
        {
            _context.Enfermeiro.Add(Enfermeiro);
            await _context.SaveChangesAsync();

            return base.CreatedAtAction("GetEnfermeiro", new { id = Enfermeiro.Id }, Enfermeiro);
        }

        // DELETE: api/Enfermeiro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermeiro(int id)
        {
            var Enfermeiro = await _context.Enfermeiro.FindAsync(id);
            if (Enfermeiro == null)
            {
                return NotFound();
            }

            _context.Enfermeiro.Remove(Enfermeiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfermeiroExists(int id)
        {
            return _context.Enfermeiro.Any(e => e.Id == id);
        }
    }
}

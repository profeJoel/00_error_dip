using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ejemploColegio.Data;
using ejemploColegio.Models;

namespace ejemploColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacionsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnotacionsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AnotacionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anotacion>>> GetAnotacions()
        {
            return await _context.Anotacions.ToListAsync();
        }

        // GET: api/AnotacionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anotacion>> GetAnotacion(int id)
        {
            var anotacion = await _context.Anotacions.FindAsync(id);

            if (anotacion == null)
            {
                return NotFound();
            }

            return anotacion;
        }

        // PUT: api/AnotacionsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnotacion(int id, Anotacion anotacion)
        {
            if (id != anotacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(anotacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnotacionExists(id))
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

        // POST: api/AnotacionsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anotacion>> PostAnotacion(Anotacion anotacion)
        {
            _context.Anotacions.Add(anotacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnotacion", new { id = anotacion.Id }, anotacion);
        }

        // DELETE: api/AnotacionsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnotacion(int id)
        {
            var anotacion = await _context.Anotacions.FindAsync(id);
            if (anotacion == null)
            {
                return NotFound();
            }

            _context.Anotacions.Remove(anotacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnotacionExists(int id)
        {
            return _context.Anotacions.Any(e => e.Id == id);
        }
    }
}

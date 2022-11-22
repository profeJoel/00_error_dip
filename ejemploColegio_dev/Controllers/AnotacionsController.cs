using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ejemploColegio.Data;
using ejemploColegio.Models;

namespace ejemploColegio.Controllers
{
    public class AnotacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnotacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /******************************************************************************/
        // GET: Anotacions
        public async Task<IActionResult> VueIndex()
        {
            return View();
        }
        public async Task<IActionResult> VueDetail(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }
        public async Task<IActionResult> VueCreate()
        {
            return View();
        }
        public async Task<IActionResult> VueEdit(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions.FindAsync(id);
            if (anotacion == null)
            {
                return NotFound();
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Id", anotacion.EstudianteId);
            return View(anotacion);
        }
        public async Task<IActionResult> VueDelete(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }


        /******************************************************************************/

        // GET: Anotacions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Anotacions.Include(a => a.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Anotacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }

        // GET: Anotacions/Create
        public IActionResult Create()
        {
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Id");
            return View();
        }

        // POST: Anotacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,FechaEmision,Descripcion,EstudianteId")] Anotacion anotacion)
        {

            if (ModelState.IsValid)
            {
                _context.Add(anotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Id", anotacion.EstudianteId);
            return View(anotacion);
        }

        // GET: Anotacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions.FindAsync(id);
            if (anotacion == null)
            {
                return NotFound();
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Id", anotacion.EstudianteId);
            return View(anotacion);
        }

        // POST: Anotacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,FechaEmision,Descripcion,EstudianteId")] Anotacion anotacion)
        {
            if (id != anotacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnotacionExists(anotacion.Id))
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
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Id", anotacion.EstudianteId);
            return View(anotacion);
        }

        // GET: Anotacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anotacions == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotacions
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }

        // POST: Anotacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anotacions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Anotacions'  is null.");
            }
            var anotacion = await _context.Anotacions.FindAsync(id);
            if (anotacion != null)
            {
                _context.Anotacions.Remove(anotacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnotacionExists(int id)
        {
          return _context.Anotacions.Any(e => e.Id == id);
        }
    }
}

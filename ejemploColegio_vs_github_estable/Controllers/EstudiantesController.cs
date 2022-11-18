using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ejemploColegio.Data;
using ejemploColegio.Models;
using Microsoft.AspNetCore.Authorization;

namespace ejemploColegio.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Estudiante.ToListAsync());
        }

        // GET: Estudiantes/Buscar
        public async Task<IActionResult> Buscar()
        {
            return View();
        }

        // POST: Estudiantes/MostrarResultadosBusqueda
        public async Task<IActionResult> MostrarResultadosBusqueda(string Busqueda)
        {
            // Consulta con Operación Lambda
            //return View("Index", await _context.Estudiante.Where( e => e.Nombre.Contains(Busqueda)).ToListAsync());

            //LINQ
            /*return View("Index", await (from e in _context.Estudiante
                                        where e.Nombre.Contains(Busqueda) || e.Apellido.Contains(Busqueda)
                                        select e
                                        ).ToListAsync());
            */

            // SQL
            return View("Index", await _context.Estudiante.FromSqlRaw(
                $"SELECT * FROM Estudiante WHERE Nombre LIKE '%{Busqueda}%' OR Apellido LIKE '%{Busqueda}%'"
                ).ToListAsync());

        }


        // GET: Estudiantes/Seleccionar
        public async Task<IActionResult> Seleccionar()
        {
            return View();
        }

        // POST: Estudiantes/MostrarEstudiantesFiltrados
        public async Task<IActionResult> MostrarEstudiantesFiltrados(string tipo, string Numero)
        {
            // Mayor a Numero de años
            if (tipo.Equals(">"))
                return View("Index", await (from e in _context.Estudiante
                                        where DateTime.Now.AddYears(Convert.ToInt32(Numero) * (-1)) > e.FechaNacimiento
                                        select e
                                        ).ToListAsync());
            // Mayor Igual
            if (tipo.Equals(">="))
                return View("Index", await (from e in _context.Estudiante
                                            where DateTime.Now.AddYears(Convert.ToInt32(Numero) * (-1)) >= e.FechaNacimiento
                                            select e
                                        ).ToListAsync());
            // Menor
            if (tipo.Equals("<"))
                return View("Index", await (from e in _context.Estudiante
                                            where DateTime.Now.AddYears(Convert.ToInt32(Numero) * (-1)) < e.FechaNacimiento
                                            select e
                                        ).ToListAsync());

            // Menor Igual
            if (tipo.Equals("<="))
                return View("Index", await (from e in _context.Estudiante
                                            where DateTime.Now.AddYears(Convert.ToInt32(Numero) * (-1)) <= e.FechaNacimiento
                                            select e
                                        ).ToListAsync());

            return View(await _context.Estudiante.ToListAsync());
        }
        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rut,Nombre,Apellido,FechaNacimiento,Domicilio")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rut,Nombre,Apellido,FechaNacimiento,Domicilio")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
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
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudiante == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estudiante'  is null.");
            }
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
          return _context.Estudiante.Any(e => e.Id == id);
        }
    }
}

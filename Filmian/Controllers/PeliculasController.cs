using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmian.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filmian.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly DBContext _context;

        public PeliculasController(DBContext context)
        {
            _context = context;
        }

		public override void OnActionExecuting( ActionExecutingContext context ) 
		{
			ViewBag.Section = "Peliculas";
			base.OnActionExecuting( context );
		}

        // GET: Peliculas
        public async Task<IActionResult> Index( string sortOrder )
        {
			ViewBag.Titulo_Sort		= sortOrder == "Titulo_ASC" ? "Titulo_DESC" : "Titulo_ASC";
			ViewBag.Duracion_Sort	= sortOrder == "Duracion_ASC" ? "Duracion_DESC" : "Duracion_ASC";
			ViewBag.Director_Sort	= sortOrder == "Director_ASC" ? "Director_DESC" : "Director_ASC";

            var peliculas = await _context.Peliculas.Include(p => p.Director).ToListAsync();

			switch ( sortOrder ) {
				case "Titulo_ASC" :
					peliculas = peliculas.OrderBy( film => film.Titulo ).ToList();
					break;
				case "Titulo_DESC" :
					peliculas = peliculas.OrderByDescending( film => film.Titulo ).ToList();
					break;
				case "Duracion_ASC" :
					peliculas = peliculas.OrderBy( film => film.Duracion ).ToList();
					break;
				case "Duracion_DESC" :
					peliculas = peliculas.OrderByDescending( film => film.Duracion ).ToList();
					break;
				case "Director_ASC" :
					peliculas = peliculas.OrderBy( film => film.Director.Nombre ).ToList();
					break;
				case "Director_DESC" :
					peliculas = peliculas.OrderByDescending( film => film.Director.Nombre ).ToList();
					break;
				default :
					peliculas = peliculas.OrderBy( film => film.Titulo ).ToList();
					break;
			}

			ViewBag.SortOrder = sortOrder;

            return View( peliculas );
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Director)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_context.Directors, "DirectorID", "DirectorID");
            return View( new Pelicula());
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,Titulo,Duracion,DirectorId")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "DirectorID", "DirectorID", pelicula.DirectorId);
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "DirectorID", "DirectorID", pelicula.DirectorId);
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("PeliculaId,Titulo,Duracion,DirectorId")] Pelicula pelicula)
        {
            if (id != pelicula.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.PeliculaId))
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
            ViewData["DirectorId"] = new SelectList(_context.Directors, "DirectorID", "DirectorID", pelicula.DirectorId);
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Director)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(short id)
        {
            return _context.Peliculas.Any(e => e.PeliculaId == id);
        }
    }
}

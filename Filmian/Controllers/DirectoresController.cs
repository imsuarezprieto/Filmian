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
    public class DirectoresController : Controller
    {
        private readonly DBContext _context;

        public DirectoresController(DBContext context)
        {
            _context = new Models.DBContext();
        }

		public override void OnActionExecuting( ActionExecutingContext context ) 
		{
			ViewBag.Section = "Directores";
			base.OnActionExecuting( context );
		}

		// GET: Directores
		public async Task<IActionResult> Index( string sortOrder )
        {
			ViewBag.Nombre_Sort = sortOrder == "Nombre_ASC" ? "Nombre_DESC" : "Nombre_ASC";
			ViewBag.Pais_Sort	= sortOrder == "Pais_ASC" ? "Pais_DESC" : "Pais_ASC";
			ViewBag.FechaNacimiento_Sort = sortOrder == "FechaNacimiento_ASC" ? "FechaNacimiento_DESC" : "FechaNacimiento_ASC";

			var directors = await _context.Directors.ToListAsync();
			
			switch ( sortOrder ) {
				case "Nombre_ASC" :
					directors = directors.OrderBy( director => director.Nombre ).ToList();
					break;
				case "Nombre_DESC" :
					directors = directors.OrderByDescending( director => director.Nombre ).ToList();
					break;
				case "Pais_ASC" :
					directors = directors.OrderBy( director => director.Pais.Nombre ).ToList();
					break;
				case "Pais_DESC" :
					directors = directors.OrderByDescending( director => director.Pais.Nombre ).ToList();
					break;
				case "FechaNacimiento_ASC" :
					directors = directors.OrderBy( director => director.FechaNacimiento ).ToList();
					break;
				case "FechaNacimiento_DESC" :
					directors = directors.OrderByDescending( director => director.FechaNacimiento ).ToList();
					break;
				default:
					directors = directors.OrderBy( director => director.Nombre ).ToList();
					break;
			}

			ViewBag.SortOrder = sortOrder;

            return View( directors );
        }

        // GET: Directores/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .FirstOrDefaultAsync(m => m.DirectorID == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directores/Create
        public IActionResult Create()
        {
            return View(new Director());
        }

        // POST: Directores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectorID,Nombre,PaisId,FechaNacimiento")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directores/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // POST: Directores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("DirectorID,Nombre,Nacionalidad,FechaNacimiento")] Director director)
        {
            if (id != director.DirectorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.DirectorID))
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
            return View(director);
        }

        // GET: Directores/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .FirstOrDefaultAsync(m => m.DirectorID == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var director = await _context.Directors.FindAsync(id);
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(short id)
        {
            return _context.Directors.Any(e => e.DirectorID == id);
        }
    }
}

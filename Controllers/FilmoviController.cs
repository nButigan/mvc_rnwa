using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RNWA_MVC.Models;

namespace RNWA_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FilmoviController : Controller
    {
        private readonly RNWA_MVC_context _context;

        public FilmoviController(RNWA_MVC_context context)
        {
            _context = context;
        }

        // GET: Filmovi
        public async Task<IActionResult> Index()
        {
            return View(await _context.filmovi.ToListAsync());
        }

        // GET: Filmovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmovi = await _context.filmovi
                .FirstOrDefaultAsync(m => m.id == id);
            if (filmovi == null)
            {
                return NotFound();
            }

            return View(filmovi);
        }

        // GET: Filmovi/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            return View(new Filmovi());
            else
                return View(_context.filmovi.Find(id));
        }

        // POST: Filmovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("id,nazivFilma,opis,trajanje,redatelji,glumci,godinaProdukcije")] Filmovi filmovi)
        {
            if (ModelState.IsValid)
            {
                if(filmovi.id == 0)
                _context.Add(filmovi);
                else
                    _context.Update(filmovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmovi);
        }


        // GET: Filmovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var film = await _context.filmovi.FindAsync(id);
            _context.filmovi.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

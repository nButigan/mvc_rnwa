using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RNWA_MVC.Models;

namespace RNWA_MVC.Controllers
{
    public class ZanroviController : Controller
    {
        private readonly RNWA_MVC_context _context;

        public ZanroviController(RNWA_MVC_context context)
        {
            _context = context;
        }

        // GET: Zanrovi
        public async Task<IActionResult> Index()
        {
            return View(await _context.zanrovi.ToListAsync());
        }

        // GET: Zanrovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanrovi = await _context.zanrovi
                .FirstOrDefaultAsync(m => m.id == id);
            if (zanrovi == null)
            {
                return NotFound();
            }

            return View(zanrovi);
        }

        // GET: Zanrovi/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Zanrovi());
            else
                return View(_context.zanrovi.Find(id));
        }

        // POST: Zanrovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("id,nazivZanra")] Zanrovi zanrovi)
        {
            if (ModelState.IsValid)
            {
                if (zanrovi.id == 0)
                    _context.Add(zanrovi);
                else
                    _context.Update(zanrovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanrovi);
        }

       

       

        // GET: Zanrovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var zanr = await _context.zanrovi.FindAsync(id);
            _context.zanrovi.Remove(zanr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

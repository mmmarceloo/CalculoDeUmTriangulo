using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultaCep.Data;
using ConsultaCep.Models;

namespace ConsultaCep.Controllers
{
    public class CepsController : Controller
    {
        private readonly ConsultaCepContext _context;

        public CepsController(ConsultaCepContext context)
        {
            _context = context;
        }

        // GET: Ceps
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cep.ToListAsync());
        }

        // GET: Ceps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cep == null)
            {
                return NotFound();
            }

            var cep = await _context.Cep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cep == null)
            {
                return NotFound();
            }

            return View(cep);
        }

        // GET: Ceps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ceps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CEP,Logradouro,Complemento,Bairro,Localidade,Uf,unidade,Ibge,Gia")] Cep cep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cep);
        }

        // GET: Ceps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cep == null)
            {
                return NotFound();
            }

            var cep = await _context.Cep.FindAsync(id);
            if (cep == null)
            {
                return NotFound();
            }
            return View(cep);
        }

        // POST: Ceps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CEP,Logradouro,Complemento,Bairro,Localidade,Uf,unidade,Ibge,Gia")] Cep cep)
        {
            if (id != cep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CepExists(cep.Id))
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
            return View(cep);
        }

        // GET: Ceps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cep == null)
            {
                return NotFound();
            }

            var cep = await _context.Cep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cep == null)
            {
                return NotFound();
            }

            return View(cep);
        }

        // POST: Ceps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cep == null)
            {
                return Problem("Entity set 'ConsultaCepContext.Cep'  is null.");
            }
            var cep = await _context.Cep.FindAsync(id);
            if (cep != null)
            {
                _context.Cep.Remove(cep);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CepExists(int id)
        {
          return _context.Cep.Any(e => e.Id == id);
        }
    }
}

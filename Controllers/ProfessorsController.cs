using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEduEscola.Context;
using SistemaEduEscola.Models;

namespace SistemaEduEscola.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly TabelaEscola _context;

        public ProfessorsController(TabelaEscola context)
        {
            _context = context;
        }

        //// GET: Professors
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Professors.ToListAsync());
        //}



        public ActionResult Index(string Pesquisar = "")
        {

            var professor = _context.Professors.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisar))
                professor = professor.Where(c => c.NomeProfessor.Contains(Pesquisar));
            professor = professor.OrderBy(c => c.NomeProfessor);

            //return View(await _context.Alunos.ToListAsync());
            return View(professor.ToList());
        }



        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProfessor,UnidadeId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProfessor,UnidadeId")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
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
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
    }
}

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
    public class TurmasController : Controller
    {
        private readonly TabelaEscola _context;

        public TurmasController(TabelaEscola context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var tabelaEscola = _context.Turmas.Include(t => t.Alunos);
            return View(await tabelaEscola.ToListAsync());
        }

        //ADICIONA A PESQUISA PELA TURMA

        /*public ActionResult Index(string Pesquisar = "")
        {

            var turma = _context.Turmas.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisar))
                turma = turma.Where(c => c.CodigoTurma.Contains(Pesquisar));
            turma = turma.OrderBy(c => c.CodigoTurma);

            //return View(await _context.Alunos.ToListAsync());
            return View(turma.ToList());
        }*/


        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Alunos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            ViewData["QtdAlunos"] = new SelectList(_context.Alunos, "Id", "Id");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoTurma,QtdAlunos,UnidadeId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QtdAlunos"] = new SelectList(_context.Alunos, "Id", "Id", turma.QtdAlunos);
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["QtdAlunos"] = new SelectList(_context.Alunos, "Id", "Id", turma.QtdAlunos);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoTurma,QtdAlunos,UnidadeId")] Turma turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
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
            ViewData["QtdAlunos"] = new SelectList(_context.Alunos, "Id", "Id", turma.QtdAlunos);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Alunos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.Id == id);
        }
    }
}

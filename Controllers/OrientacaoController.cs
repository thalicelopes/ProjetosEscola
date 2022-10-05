using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetosEscola.Models;

namespace ProjetosEscola.Controllers
{
    public class OrientacaoController : Controller
    {
        private readonly ProjetoEscolaContext _context;

        public OrientacaoController(ProjetoEscolaContext context)
        {
            _context = context;
        }

        // GET: Orientacao
        public async Task<IActionResult> Index()
        {
            var projetoEscolaContext = _context.Orientacao.Include(o => o.Aluno).Include(o => o.Professor);
            return View(await projetoEscolaContext.ToListAsync());
        }

        // GET: Orientacao/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Orientacao == null)
            {
                return NotFound();
            }

            var orientacao = _context.Orientacao
                .Include(o => o.Aluno)
                .Include(o => o.Professor)
                .Where(m => m.Id == id).FirstOrDefault();
            if (orientacao == null)
            {
                return NotFound();
            }

            return View(orientacao);
        }

        // GET: Orientacao/Create
        public IActionResult Create()
        {
            ViewData["IdAluno"] = new SelectList(_context.Aluno, "Id", "NomeAluno");
            ViewData["IdProfessor"] = new SelectList(_context.Professor, "Id", "NomeProfessor");
            return View();
        }

        // POST: Orientacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAluno,IdProfessor,NomeProjeto,DataLimite")] Orientacao orientacao)
        {
            try
            {
                _context.Add(orientacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }

            ViewData["IdAluno"] = new SelectList(_context.Aluno, "Id", "NomeAluno", orientacao.IdAluno);
            ViewData["IdProfessor"] = new SelectList(_context.Professor, "Id", "NomeProfessor", orientacao.IdProfessor);
            return View(orientacao);
        }

        // GET: Orientacao/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Orientacao == null)
            {
                return NotFound();
            }

            var orientacao = _context.Orientacao.Where(m => m.Id == id).FirstOrDefault();
            if (orientacao == null)
            {
                return NotFound();
            }
            ViewData["IdAluno"] = new SelectList(_context.Aluno, "Id", "NomeAluno", orientacao.IdAluno);
            ViewData["IdProfessor"] = new SelectList(_context.Professor, "Id", "NomeProfessor", orientacao.IdProfessor);
            return View(orientacao);
        }

        // POST: Orientacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Orientacao orientacao)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                Orientacao? orientacaoEditar = _context.Orientacao?.Where(x => x.Id == id).FirstOrDefault();
                orientacaoEditar.IdAluno = orientacao.IdAluno;
                orientacaoEditar.IdProfessor = orientacao.IdProfessor;
                orientacaoEditar.NomeProjeto = orientacao.NomeProjeto;
                orientacaoEditar.DataLimite = orientacao.DataLimite;
                _context.Update(orientacaoEditar);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (!OrientacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["IdAluno"] = new SelectList(_context.Aluno, "Id", "NomeAluno", orientacao.IdAluno);
            ViewData["IdProfessor"] = new SelectList(_context.Professor, "Id", "NomeProfessor", orientacao.IdProfessor);
            return RedirectToAction("Edit", new { orientacao.IdAluno, orientacao.IdProfessor });
        }

        // GET: Orientacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orientacao == null)
            {
                return NotFound();
            }

            var orientacao = await _context.Orientacao
                .Include(o => o.Aluno)
                .Include(o => o.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orientacao == null)
            {
                return NotFound();
            }

            return View(orientacao);
        }

        // POST: Orientacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("Id")] Orientacao orientacaoDeletada)
        {
            if (_context.Orientacao == null)
            {
                return Problem("Entity set 'ProjetoEscolaContext.Orientacao'  is null.");
            }
            var orientacao = _context.Orientacao.Where(x => x.Id == orientacaoDeletada.Id).FirstOrDefault();
            if (orientacao != null)
            {
                _context.Orientacao.Remove(orientacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrientacaoExists(int? id)
        {
            return (_context.Orientacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadraoRepositorio.AcessoDados.Interface;
using PadraoRepositorio.Models;

namespace PadraoRepositorio.Controllers
{
    public class PessoasController : Controller
    {       
        private readonly IPessoaRepositorio _pessoaRepositorio;       

        public PessoasController(IPessoaRepositorio pessoaRepositorio)
        {           
            _pessoaRepositorio = pessoaRepositorio;           
        }

        // GET: Pessoas
        public IActionResult Index()
        {
            return View(_pessoaRepositorio.PegarTodos());
        }

        // GET: Pessoas/Details/5
        public IActionResult Details(int id)
        {

            var pessoa = _pessoaRepositorio.PegarPeloId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PessoaId,Nome,Idade")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepositorio.InserirPessoa(pessoa);
                _pessoaRepositorio.Salvar();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public IActionResult Edit(int id)
        {
            var pessoa = _pessoaRepositorio.PegarPeloId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PessoaId,Nome,Idade")] Pessoa pessoa)
        {
            if (id != pessoa.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pessoaRepositorio.AtualizarPessoa(pessoa);
                    _pessoaRepositorio.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public IActionResult Delete(int id)
        {
            var pessoa = _pessoaRepositorio.PegarPeloId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _pessoaRepositorio.ExcluirPessoa(id);
            _pessoaRepositorio.Salvar();
            return RedirectToAction(nameof(Index));
        }       
    }
}

using Microsoft.EntityFrameworkCore;
using PadraoRepositorio.AcessoDados.Interface;
using PadraoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepositorio.AcessoDados.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {

        private readonly Contexto _contexto;

        public PessoaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            _contexto.Entry(pessoa).State = EntityState.Modified;
        }

        public void ExcluirPessoa(int id)
        {
            Pessoa pessoa = PegarPeloId(id);
            _contexto.Pessoas.Remove(pessoa);
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            _contexto.Pessoas.Add(pessoa);
        }

        public Pessoa PegarPeloId(int id)
        {
            return _contexto.Pessoas.Find(id);
        }

        public IEnumerable<Pessoa> PegarTodos()
        {
            return _contexto.Pessoas.ToList();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}

using PadraoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepositorio.AcessoDados.Interface
{
    public interface IPessoaRepositorio
    {
        IEnumerable<Pessoa> PegarTodos();
        Pessoa PegarPeloId(int id);
        void InserirPessoa(Pessoa pessoa);
        void AtualizarPessoa(Pessoa pessoa);
        void ExcluirPessoa(int id);
        void Salvar();
    }
}

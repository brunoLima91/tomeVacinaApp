using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task Remover(Guid id);
    }
}

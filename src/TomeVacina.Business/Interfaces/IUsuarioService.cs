using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Interfaces
{
	public interface IUsuarioService : IDisposable
	{
		Task Adicionar(Usuario usuario);
		Task Atualizar(Usuario usuario);
		Task Remover(Guid id);
	}
}

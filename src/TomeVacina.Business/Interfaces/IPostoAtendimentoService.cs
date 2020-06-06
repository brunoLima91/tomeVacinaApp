using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Interfaces
{
	public interface IPostoAtendimentoService : IDisposable
	{
		Task Adicionar(PostoAtendimento postoAtendimento);
		Task Atualizar(PostoAtendimento postoAtendimento);
		Task Remover(Guid id);
	}
}

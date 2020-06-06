using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Interfaces
{
	public interface IAgendamentoService : IDisposable
	{
		Task Adicionar(Agendamento agendamento);
		Task Atualizar(Agendamento agendamento);
		Task Remover(Guid id);
	}
}

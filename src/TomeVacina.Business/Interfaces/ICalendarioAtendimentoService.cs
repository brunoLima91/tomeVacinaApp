using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Interfaces
{
	public interface ICalendarioAtendimentoService : IDisposable
	{
		Task Adicionar(CalendarioAtendimento calendarioAtendimento);
		Task Atualizar(CalendarioAtendimento calendarioAtendimento);
		Task Remover(Guid id);
	}
}

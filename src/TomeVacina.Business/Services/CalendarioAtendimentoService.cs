using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Services
{
	public class CalendarioAtendimentoService : BaseService, ICalendarioAtendimentoService
	{
		private readonly ICalendarioAtendimentoRepository _calendarioAtendimentoRepository;

		public CalendarioAtendimentoService(ICalendarioAtendimentoRepository calendarioAtendimentoRepository)
		{
			_calendarioAtendimentoRepository = calendarioAtendimentoRepository;
		}

		public async Task Adicionar(CalendarioAtendimento calendarioAtendimento)
		{
			// Validações a serem implementadas

			//if (_calendarioAtendimentoRepository.Buscar(f => f.Usuario == agendamento.Usuario).Result.Any())
			//{
			//	//Notificar("Já existe um fornecedor com este documento informado.");
			//	return;
			//}
			await _calendarioAtendimentoRepository.Adicionar(calendarioAtendimento);
		}

		public async Task Atualizar(CalendarioAtendimento calendarioAtendimento)
		{
			//if (_agendamentoRepository.Buscar(f => f.Usuario == agendamento.Usuario).Result.Any())
			//{
			//	//Notificar("Já existe um fornecedor com este documento informado.");
			//	return;
			//}

			await _calendarioAtendimentoRepository.Atualizar(calendarioAtendimento);
		}

		public async Task Remover(Guid id)
		{
			//Validações

			await _calendarioAtendimentoRepository.Remover(id);
		}

		public void Dispose()
		{
			_calendarioAtendimentoRepository?.Dispose();
			_calendarioAtendimentoRepository?.Dispose();
		}
	}
}

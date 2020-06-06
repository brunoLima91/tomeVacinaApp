using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Services
{
	public class AgendamentoService : BaseService, IAgendamentoService
	{
		private readonly IAgendamentoRepository _agendamentoRepository;

		public AgendamentoService(IAgendamentoRepository agendamentoRepository)
		{
			_agendamentoRepository = agendamentoRepository;
		}

		public async Task Adicionar(Agendamento agendamento)
		{
			// Validações a serem implementadas

			if (_agendamentoRepository.Buscar(f => f.Usuario == agendamento.Usuario).Result.Any())
			{
				//Notificar("Já existe um fornecedor com este documento informado.");
				return;
			}
			await _agendamentoRepository.Adicionar(agendamento);
		}

		public async Task Atualizar(Agendamento agendamento)
		{
			if (_agendamentoRepository.Buscar(f => f.Usuario == agendamento.Usuario).Result.Any())
			{
				//Notificar("Já existe um fornecedor com este documento informado.");
				return;
			}

			await _agendamentoRepository.Atualizar(agendamento);
		}

		public async Task Remover(Guid id)
		{
			//Validações

			await _agendamentoRepository.Remover(id);
		}

		public void Dispose()
		{
			_agendamentoRepository?.Dispose();
			_agendamentoRepository?.Dispose();
		}
	}
}

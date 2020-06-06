using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Services
{
	public class EnderecoService : BaseService, IEnderecoService
	{
		private readonly IEnderecoRepository _enderecoRepository;

		public EnderecoService(IEnderecoRepository enderecoRepository)
		{
			_enderecoRepository = enderecoRepository;
		}

		public async Task Adicionar(Endereco endereco)
		{
			// Validar o estado da entidadde
			

			await _enderecoRepository.Adicionar(endereco);
		}

		public async Task Atualizar(Endereco endereco)
		{


			await _enderecoRepository.Atualizar(endereco);
		}

		
		public async Task Remover(Guid id)
		{

			await _enderecoRepository.Remover(id);
		}

		public void Dispose()
		{
			_enderecoRepository?.Dispose();
			_enderecoRepository?.Dispose();
		}
	}
}

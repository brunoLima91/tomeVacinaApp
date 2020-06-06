using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Services
{
	public class PostoAtendimentoService : BaseService, IPostoAtendimentoService
	{
		private readonly IPostoAtendimentoRepository _postoAtendimentoRepository;

		public PostoAtendimentoService(IPostoAtendimentoRepository postoAtendimentoRepository)
		{
			_postoAtendimentoRepository = postoAtendimentoRepository;
		}

		public async Task Adicionar(PostoAtendimento postoAtendimento)
		{
			// Validar o estado da entidadde
			//if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
			//	|| !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

			//if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
			//{
			//	Notificar("Já existe um fornecedor com este documento informado.");
			//	return;
			//}

			await _postoAtendimentoRepository.Adicionar(postoAtendimento);
		}

		public async Task Atualizar(PostoAtendimento postoAtendimento)
		{
			//if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

			//if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
			//{
			//	Notificar("Já existe um fornecedor com este documento informado.");
			//	return;
			//}

			await _postoAtendimentoRepository.Atualizar(postoAtendimento);
		}


		public async Task Remover(Guid id)
		{
			//if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
			//{
			//	Notificar("O fornecedor informado possui produtos cadastrados");
			//	return;
			//}

			await _postoAtendimentoRepository.Remover(id);
		}

		public void Dispose()
		{
			_postoAtendimentoRepository?.Dispose();
			_postoAtendimentoRepository?.Dispose();
		}
	}
}

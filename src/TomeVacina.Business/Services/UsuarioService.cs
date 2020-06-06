using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.Business.Services
{
	public class UsuarioService : BaseService, IUsuarioService
	{
		private readonly IUsuarioService _usuarioRepository;

		public UsuarioService(IUsuarioService usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task Adicionar(Usuario usuario)
		{
			//// Validar o estado da entidadde


			await _usuarioRepository.Adicionar(usuario);
		}

		public async Task Atualizar(Usuario usuario)
		{


			await _usuarioRepository.Atualizar(usuario);
		}

		public async Task Remover(Guid id)
		{


			await _usuarioRepository.Remover(id);
		}

		public void Dispose()
		{
			_usuarioRepository?.Dispose();
			_usuarioRepository?.Dispose();
		}


	}
}

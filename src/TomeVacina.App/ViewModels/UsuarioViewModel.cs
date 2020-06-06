using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TomeVacina.App.ViewModels
{
	public class UsuarioViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Documento { get; set; }
		public DateTime DataNascimento { get; set; }
		public bool Prioridade { get; set; }

		public EnderecoViewModel Endereco { get; set; }
	}
}

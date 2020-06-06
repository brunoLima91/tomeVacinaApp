using System;
using System.Collections.Generic;
using System.Text;

namespace TomeVacina.Business.Models
{
	public class Endereco: Entity
	{
		public Guid UsuarioId { get; set; }
		public Guid PostoAtendimentoId { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Cep { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }

		/* EF */
		public Usuario Usuario { get; set; }
		public PostoAtendimento PostoAtendimento { get; set; }
	}
}

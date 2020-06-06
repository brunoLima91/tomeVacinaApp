using System;
using System.Collections.Generic;
using System.Text;

namespace TomeVacina.Business.Models
{
	public class Usuario: Entity
	{
		public string Nome { get; set; }
		public string Documento { get; set; }
		public DateTime DataNascimento { get; set; }
		public bool Prioridade { get; set; }

		public Endereco Endereco { get; set; }
	}
}

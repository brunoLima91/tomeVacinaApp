using System;
using System.Collections.Generic;
using System.Text;

namespace TomeVacina.Business.Models
{
	public class PostoAtendimento : Entity
	{
		public string Nome { get; set; }
		public int QtdVacina { get; set; }
		public Endereco Endereco { get; set; }
		public TipoPostoAtendimento TipoPostoAtendimento { get; set; }

		/* EF Relations */
		public IEnumerable<CalendarioAtendimento> CalendarioAtendimento { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TomeVacina.Business.Models
{
	public class Agendamento: Entity
	{
		public Guid UsuarioId { get; set; }
		public Guid CalendarioAtendimentoId { get; set; }		
		public bool Realizado { get; set; }

		

		/* EF */
		public Usuario Usuario { get; set; }
		public CalendarioAtendimento CalendarioAtendimento { get; set; }
	}
}

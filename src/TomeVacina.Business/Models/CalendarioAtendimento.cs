using System;


namespace TomeVacina.Business.Models
{
	public class CalendarioAtendimento : Entity
	{
		public DateTime DataPrevistaInicio { get; set; }
		public DateTime DataPrevistaFim { get; set; }

		public Guid PostoAtendimentoId { get; set; }
		public Guid AgendamentoId { get; set; }

		/* EF Relation */
		public PostoAtendimento PostoAtendimento { get; set; }
		
	}
}

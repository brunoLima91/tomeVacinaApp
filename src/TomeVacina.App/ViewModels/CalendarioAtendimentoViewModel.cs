using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TomeVacina.App.ViewModels
{
	public class CalendarioAtendimentoViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public DateTime DataPrevistaInicio { get; set; }
		public DateTime DataPrevistaFim { get; set; }
		
		public PostoAtendimentoViewModel PostoAtendimento { get; set; }
		
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TomeVacina.App.ViewModels
{
	public class AgendamentoViewModel
	{
		
		[Key]
		public Guid Id { get; set; }
		public bool Realizado { get; set; }
		public UsuarioViewModel Usuario { get; set; }
		public CalendarioAtendimentoViewModel CalendarioAtendimento { get; set; }
	}
}

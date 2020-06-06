using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TomeVacina.App.ViewModels
{
	public class PostoAtendimentoViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int QtdVacina { get; set; }
		public EnderecoViewModel Endereco { get; set; }
		public int TipoPostoAtendimento { get; set; }
		
		public IEnumerable<CalendarioAtendimentoViewModel> CalendarioAtendimento { get; set; }
	}
}

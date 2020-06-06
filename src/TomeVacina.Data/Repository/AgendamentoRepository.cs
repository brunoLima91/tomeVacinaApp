using System;
using System.Collections.Generic;
using System.Text;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;
using TomeVacina.Data.Context;

namespace TomeVacina.Data.Repository
{
	public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
	{
		public AgendamentoRepository(TomeVacinaDbContext db) : base(db)
		{
		}
	}
}

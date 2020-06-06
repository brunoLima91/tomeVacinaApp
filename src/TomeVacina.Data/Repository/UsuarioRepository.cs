using System;
using System.Collections.Generic;
using System.Text;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;
using TomeVacina.Data.Context;

namespace TomeVacina.Data.Repository
{
	public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(TomeVacinaDbContext db) : base(db)
		{
		}
	}
}

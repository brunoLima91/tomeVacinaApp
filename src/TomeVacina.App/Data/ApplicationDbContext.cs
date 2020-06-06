using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TomeVacina.App.ViewModels;

namespace TomeVacina.App.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<TomeVacina.App.ViewModels.UsuarioViewModel> UsuarioViewModel { get; set; }
		public DbSet<TomeVacina.App.ViewModels.PostoAtendimentoViewModel> PostoAtendimentoViewModel { get; set; }
		public DbSet<TomeVacina.App.ViewModels.AgendamentoViewModel> AgendamentoViewModel { get; set; }
	}
}

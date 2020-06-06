using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomeVacina.Business.Models;

namespace TomeVacina.Data.Context
{
	public class TomeVacinaDbContext : DbContext
	{
		public TomeVacinaDbContext(DbContextOptions options): base(options)
		{

		}

		public DbSet<Agendamento> Agendamento { get; set; }
		public DbSet<CalendarioAtendimento> CalendarioAtendimento { get; set; }
		public DbSet<Endereco> Endereco { get; set; }


		public DbSet<PostoAtendimento> PostoAtendimento { get; set; }
		public DbSet<Usuario> Usuario { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			foreach (var proprety in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties()
				.Where(p => p.ClrType == typeof(string))))
				proprety.SetColumnType("varchar(100)");



			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TomeVacinaDbContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TomeVacina.Business.Models;

namespace TomeVacina.Data.Mappings
{
	public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasOne(f => f.Endereco)
			.WithOne(e => e.Usuario);

			builder.ToTable("Usuarios");
		}
	}
}

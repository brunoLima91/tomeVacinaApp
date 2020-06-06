using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TomeVacina.Business.Models;

namespace TomeVacina.Data.Mappings
{
	public class PostoAtendimentoMapping : IEntityTypeConfiguration<PostoAtendimento>
	{
		public void Configure(EntityTypeBuilder<PostoAtendimento> builder)
		{
			builder.HasOne(f => f.Endereco)
				.WithOne(e => e.PostoAtendimento);
		}
	}
}

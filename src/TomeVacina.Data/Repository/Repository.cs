using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;
using TomeVacina.Data.Context;

namespace TomeVacina.Data.Repository
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
	{
		protected readonly TomeVacinaDbContext Db;
		protected readonly DbSet<TEntity> DbSet;

		protected Repository(TomeVacinaDbContext db)
		{
			Db = db;
			DbSet = db.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
		}

		public virtual async Task<TEntity> ObterPorId(Guid id)
		{
			return await DbSet.FindAsync(id);
		}

		public virtual async Task<List<TEntity>> ObterTodos()
		{
			return await DbSet.AsNoTracking().ToListAsync();
		}

		public virtual async Task Adicionar(TEntity entity)
		{
			DbSet.Add(entity);
			await SaveChanges();
		}

		public virtual async Task Atualizar(TEntity entity)
		{
			DbSet.Update(entity);
			await SaveChanges();
		}

		public virtual async Task Remover(Guid id)
		{
			DbSet.Remove(new TEntity { Id = id });
			await SaveChanges();
		}

		public async Task<int> SaveChanges()
		{
			return await Db.SaveChangesAsync();
		}

		public void Dispose()
		{
			Db?.Dispose();
		}

	}
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.DAL.Context;
using VinylStore.DAL.Extensions;

namespace VinylStore.DAL.Repositories
{
	public class EFRepository<T> : IRepository<T> where T : class
	{
		private readonly VinylStoreDbContext context;

		public EFRepository(VinylStoreDbContext context)
		{
			this.context = context;

			if (this.context is null)
			{
				throw new ArgumentNullException($"ArtistRepository : {nameof(context)} is empty");
			}
		}

		public ICollection<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public T GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public T Insert(T entity)
		{
			throw new NotImplementedException();
		}

		public T Update(T entity)
		{
			throw new NotImplementedException();
		}

		public T Delete(T entity)
		{
			throw new NotImplementedException();
		}
	}
}

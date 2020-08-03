using System;
using System.Collections.Generic;

namespace VinylStore.DAL.Interfaces
{
	public interface IRepository<T> where T : class
	{
		T Create(T entity);
		IEnumerable<T> Retrieve();
		T Retrieve(Guid id);
		T Update(T entity);
		T Delete(T entity);
	}
}

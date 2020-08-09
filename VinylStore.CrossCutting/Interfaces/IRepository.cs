using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface IRepository<T> where T : class
	{
        T GetById(Guid id);
        ICollection<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}

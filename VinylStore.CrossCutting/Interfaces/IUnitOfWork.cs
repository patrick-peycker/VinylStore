using System;
using System.Threading.Tasks;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		int SaveChanges();
	}
}

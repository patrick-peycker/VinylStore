using System;
using VinylStore.DAL.Entities;

namespace VinylStore.DAL.Interfaces
{
	public interface IArtistRepository : IRepository<Artist>
	{
		bool IsExist(Guid artistId);
	}
}

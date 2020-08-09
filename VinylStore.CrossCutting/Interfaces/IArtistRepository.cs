using System;
using System.Collections.Generic;
using VinylStore.CrossCutting.TransferObjects;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface IArtistRepository : IRepository<Artist>
	{
		bool IsExist(Guid ArtistId);
		ICollection<Artist> GetArtistsWithAlbumsInStock();
	}
}

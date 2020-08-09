using System;
using System.Collections.Generic;
using VinylStore.CrossCutting.TransferObjects;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface IAlbumRepository : IRepository<Album>
	{
		bool IsExist(Guid AlbumId);

	}
}

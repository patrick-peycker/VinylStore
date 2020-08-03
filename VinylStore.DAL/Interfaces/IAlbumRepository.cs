using System;
using System.Collections.Generic;
using VinylStore.DAL.Entities;

namespace VinylStore.DAL.Interfaces
{
	public interface IAlbumRepository : IRepository<Album>
	{
		bool IsExist(Guid albumId);
		IEnumerable<Album> RetrieveAlbumsByArtist(Guid ArtistId);
		IEnumerable<Album> RetrieveAlbumsInStock();
	}
}

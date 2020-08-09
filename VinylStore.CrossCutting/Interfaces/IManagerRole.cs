using System;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface IManagerRole
	{
		bool IsArtistInStock(Guid ArtistId);
		bool IsAlbumInStock(Guid AlbumId);
	}
}

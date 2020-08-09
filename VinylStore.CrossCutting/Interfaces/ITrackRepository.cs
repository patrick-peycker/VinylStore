using System;
using System.Collections.Generic;
using VinylStore.CrossCutting.TransferObjects;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface ITrackRepository : IRepository<Track>
	{
		//IEnumerable<Track> CreateTracksList(IEnumerable<Track> Tracks);
		//IEnumerable<Track> RetrieveTracksByAlbums(Guid AlbumId);
	}
}

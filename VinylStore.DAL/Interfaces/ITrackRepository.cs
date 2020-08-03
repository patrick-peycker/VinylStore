using System;
using System.Collections.Generic;
using VinylStore.DAL.Entities;

namespace VinylStore.DAL.Interfaces
{
	interface ITrackRepository : IRepository<Track>
	{
		IEnumerable<Track> CreateTracksList(IEnumerable<Track> tracks);
		IEnumerable<Track> RetrieveTracksByAlbums(Guid albumId);
	}
}

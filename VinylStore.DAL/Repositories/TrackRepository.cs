using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Interfaces;

namespace VinylStore.DAL.Repositories
{
	public class TrackRepository : ITrackRepository
	{
		private readonly VinylStoreDbContext context;

		public TrackRepository(VinylStoreDbContext context)
		{
			this.context = context;

			if (this.context is null)
			{
				throw new ArgumentNullException($"TrackRepository : {nameof(context)} is empty");
			}
		}
		public Track Create(Track entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Track> CreateTracksList(IEnumerable<Track> tracks)
		{
			context.Tracks.AddRange(tracks);
			return tracks;
		}

		public Track Delete(Track entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Track> Retrieve()
		{
			throw new NotImplementedException();
		}

		public Track Retrieve(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Track> RetrieveTracksByAlbums(Guid albumId)
		{
			return context.Tracks
				.Where (t=>t.AlbumId == albumId);
		}

		public Track Update(Track entity)
		{
			throw new NotImplementedException();
		}
	}
}

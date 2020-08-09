using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.CrossCutting.TransferObjects;
using VinylStore.DAL.Context;
using VinylStore.DAL.Extensions;

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
		public CrossCutting.TransferObjects.Track Create(CrossCutting.TransferObjects.Track TransferObject)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.Track> CreateTracksList(IEnumerable<CrossCutting.TransferObjects.Track> Tracks)
		{
			if (Tracks is null)
			{
				throw new ArgumentNullException($"ArtistRepository : {nameof(Tracks)} is empty");
			}

			context.Tracks.AddRangeAsync(Tracks.Select(t => t.ToEntity()));

			return Tracks;
		}

		public CrossCutting.TransferObjects.Track Delete(CrossCutting.TransferObjects.Track TransferObject)
		{
			throw new NotImplementedException();
		}

		public ICollection<Track> GetAll()
		{
			throw new NotImplementedException();
		}

		public Track GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Track Insert(Track entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.Track> Retrieve()
		{
			return context.Tracks
				.Include(t => t.Album)
				.ThenInclude(a => a.Artist)
				.Select(t => t.ToTransferObject());
		}

		public CrossCutting.TransferObjects.Track Retrieve(Guid Id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.Track> RetrieveTracksByAlbums(Guid AlbumId)
		{
			return context.Tracks
				.Where(t => t.AlbumId == AlbumId)
				.Select(t => t.ToTransferObject());
		}

		public CrossCutting.TransferObjects.Track Update(CrossCutting.TransferObjects.Track TransferObject)
		{
			throw new NotImplementedException();
		}
	}
}

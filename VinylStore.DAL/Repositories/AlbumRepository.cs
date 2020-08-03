using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Interfaces;

namespace VinylStore.DAL.Repositories
{
	public class AlbumRepository : IAlbumRepository
	{
		private readonly VinylStoreDbContext context;

		public AlbumRepository(VinylStoreDbContext context)
		{
			this.context = context;

			if (this.context is null)
			{
				throw new ArgumentNullException($"AlbumRepository : {nameof(context)} is empty");
			}
		}

		public Album Create(Album entity)
		{
			if (entity is null)
			{
				throw new ArgumentNullException($"AlbumRepository : {nameof(entity)} is empty");
			}

			var entry = context.Albums.Add(entity);

			return entry.Entity;
		}

		public Album Delete(Album entity)
		{
			throw new NotImplementedException();
		}

		public bool IsExist(Guid albumId)
		{
			return context.Albums.Any(a=> a.AlbumId == albumId);
		}

		public IEnumerable<Album> Retrieve()
		{
			return context.Albums
				.Include(a => a.Artist)
				.Include(a => a.Tracks);
		}

		public Album Retrieve(Guid id)
		{
			return context.Albums
				.Include(a => a.Artist)
				.Include(a => a.Tracks)
				.FirstOrDefault(a => a.AlbumId == id);
		}

		public IEnumerable<Album> RetrieveAlbumsByArtist(Guid ArtistId)
		{
			return context.Albums
				.Include(a => a.Artist)
				.Include(a => a.Tracks)
				.Where(a => a.ArtistId == ArtistId);
		}

		public IEnumerable<Album> RetrieveAlbumsInStock()
		{
			return context.Albums
				.Include(a => a.Artist)
				.Include(a=> a.Tracks)
				.Where(a => a.Quantity > 0);
		}

		public Album Update(Album entity)
		{
			context.Albums.Attach(entity).State = EntityState.Modified;

			return entity;
		}
	}
}

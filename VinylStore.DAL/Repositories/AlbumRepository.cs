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

		public Album Delete(Album entity)
		{
			throw new NotImplementedException();
		}

		public ICollection<Album> GetAll()
			=> context.Albums
				.Include(a => a.Tracks)
				.Select(a => a.ToTransferObject())
				.ToList();

		public Album GetById(Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentNullException(nameof(id));

			return context.Albums
				.Include(a => a.Tracks)
				.FirstOrDefault(a => a.AlbumId == id)
				.ToTransferObject();
		}

		public Album Insert(Album entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			var entry = context.Albums.Add(entity.ToEntity());

			return entry.Entity.ToTransferObject();
		}

		public bool IsExist(Guid AlbumId)
			=> context.Albums.Any(a => a.AlbumId == AlbumId);

		public Album Update(Album entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			context.Albums.Attach(entity.ToEntity()).State = EntityState.Modified;

			return entity;
		}
	}
}

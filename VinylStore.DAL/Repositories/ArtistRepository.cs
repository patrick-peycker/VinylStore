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
	public class ArtistRepository : IArtistRepository
	{
		private readonly VinylStoreDbContext context;

		public ArtistRepository(VinylStoreDbContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Artist Delete(Artist entity)
		{
			throw new NotImplementedException();
		}

		public ICollection<Artist> GetAll()
			=> context.Artists
				.Include(a => a.Albums)
				.ThenInclude(a => a.Tracks)
				.Select(a => a.ToTransferObject())
				.ToList();

		public ICollection<Artist> GetArtistsWithAlbumsInStock()
			=> context.Artists
				.Include(a => a.Albums)
				.ThenInclude(a => a.Tracks)
				.Where(a => a.Albums.Any(a => a.Quantity > 0))
				.Select(a => a.ToTransferObject())
				.ToList();

		public Artist GetById(Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentNullException(nameof(id));

			return context.Artists
				.Include(a => a.Albums)
				.ThenInclude(a => a.Tracks)
				.FirstOrDefault(a => a.ArtistId == id)
				.ToTransferObject();
		}

		public Artist Insert(Artist entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			var entry = context.Artists.Add(entity.ToEntity());

			return entry.Entity.ToTransferObject();
		}

		public bool IsExist(Guid ArtistId)
		{
			if (ArtistId == Guid.Empty)
				throw new ArgumentNullException(nameof(ArtistId));

			return context.Artists.Any(a => a.ArtistId == ArtistId);
		}
		public Artist Update(Artist entity)
		{
			throw new NotImplementedException();
		}
	}
}

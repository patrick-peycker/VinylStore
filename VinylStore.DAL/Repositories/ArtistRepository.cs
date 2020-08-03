using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Interfaces;

namespace VinylStore.DAL.Repositories
{
	public class ArtistRepository : IArtistRepository
	{
		private readonly VinylStoreDbContext context;

		public ArtistRepository(VinylStoreDbContext context)
		{
			this.context = context;

			if (this.context is null)
			{
				throw new ArgumentNullException($"ArtistRepository : {nameof(context)} is empty");
			}
		}

		public Artist Create(Artist entity)
		{
			if (entity is null)
			{
				throw new ArgumentNullException($"ArtistRepository : {nameof(entity)} is empty");
			}

			var entry = context.Artists.Add(entity);

			return entry.Entity;
		}

		public Artist Delete(Artist entity)
		{
			throw new NotImplementedException();
		}

		public bool IsExist(Guid artistId)
		{
			return context.Artists.Any(a => a.ArtistId == artistId);
		}

		public IEnumerable<Artist> Retrieve()
		{

			return context.Artists
				.Include(a => a.Albums)
				.ThenInclude(a => a.Tracks);
		}

		public Artist Retrieve(Guid id)
		{
			return context.Artists
			.Include(a => a.Albums)
			.ThenInclude(a => a.Tracks)
			.FirstOrDefault(a => a.ArtistId == id);
		}

		public Artist Update(Artist entity)
		{
			throw new NotImplementedException();
		}
	}
}

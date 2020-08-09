using System;
using System.Linq;

namespace VinylStore.DAL.Extensions
{
	public static class ArtistExtension
	{
		public static Entities.Artist ToEntity(this CrossCutting.TransferObjects.Artist TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException(nameof(TransferObject));

			return new Entities.Artist
			{
				ArtistId = TransferObject.Id,
				Name = TransferObject.Name,
				Description = TransferObject.Description,
				Country = TransferObject.Country,
				Type = TransferObject.Type,
				
				Albums = TransferObject.Albums?.Select(a => a.ToEntity()).ToList()
			};
		}

		public static CrossCutting.TransferObjects.Artist ToTransferObject(this Entities.Artist Entity)
		{
			if (Entity is null)
				throw new ArgumentNullException(nameof(Entity));

			return new CrossCutting.TransferObjects.Artist
			{
				Id = Entity.ArtistId,
				Name = Entity.Name,
				Description = Entity.Description,
				Country = Entity.Country,
				Type = Entity.Type,
								
				Albums = Entity.Albums?.Select(a => a.ToTransferObject()).ToList()
			};
		}
	}
}

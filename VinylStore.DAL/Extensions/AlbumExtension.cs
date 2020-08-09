using System;
using System.Linq;

namespace VinylStore.DAL.Extensions
{
	public static class AlbumExtension
	{
		public static Entities.Album ToEntity(this CrossCutting.TransferObjects.Album TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException(nameof(TransferObject));

			return new Entities.Album
			{
				AlbumId = TransferObject.Id,
				Title = TransferObject.Title,
				Date = TransferObject.Date,
				Barcode = TransferObject.Barcode,
				Country = TransferObject.Country,
				Price = TransferObject.Price,
				Quantity = TransferObject.Quantity,

				Tracks = TransferObject.Tracks?.Select(t => t.ToEntity()).ToList()
			};
		}

		public static CrossCutting.TransferObjects.Album ToTransferObject(this Entities.Album Entity)
		{
			if (Entity is null)
				throw new ArgumentNullException(nameof(Entity));

			return new CrossCutting.TransferObjects.Album
			{
				Id = Entity.AlbumId,
				Title = Entity.Title,
				Date = Entity.Date,
				Barcode = Entity.Barcode,
				Country = Entity.Country,
				Price = Entity.Price,
				Quantity = Entity.Quantity,
				ArtistId = Entity.ArtistId,
				
				Tracks = Entity.Tracks?.Select(t => t.ToTransferObject()).ToList()
			};
		}
	}
}

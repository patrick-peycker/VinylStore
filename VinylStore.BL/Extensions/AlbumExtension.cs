using System.Linq;

namespace VinylStore.BL.Extensions
{
	public static class AlbumExtension
	{
		public static Domain.Album ToDomain (this CrossCutting.TransferObjects.Album TransferObject)
		{
			return new Domain.Album
			{
				Id = TransferObject.Id,
				Title = TransferObject.Title,
				Date = TransferObject.Date,
				Barcode = TransferObject.Barcode,
				Country = TransferObject.Country,
				Price = TransferObject.Price,
				Quantity = TransferObject.Quantity,

				Tracks = TransferObject.Tracks.Select(t => t.ToDomain()).ToList(),

				ArtistId = TransferObject.ArtistId
			};
		}

		public static CrossCutting.TransferObjects.Album ToTranferObject (this Domain.Album Domain)
		{
			return new CrossCutting.TransferObjects.Album
			{
				Id = Domain.Id,
				Title = Domain.Title,
				Date = Domain.Date,
				Barcode = Domain.Barcode,
				Country = Domain.Country,
				Price = Domain.Price,
				Quantity = Domain.Quantity,

				Tracks = Domain.Tracks.Select(t=>t.ToTransferObject()).ToList(),

				ArtistId = Domain.ArtistId
			};
		}
	}
}

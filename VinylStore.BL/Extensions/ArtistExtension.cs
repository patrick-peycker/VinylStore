using System.Linq;

namespace VinylStore.BL.Extensions
{
	public static class ArtistExtension
	{
		public static Domain.Artist ToDomain(this CrossCutting.TransferObjects.Artist TransferObject)
		{
			return new Domain.Artist
			{ 
				Id = TransferObject.Id,
				Name = TransferObject.Name,
				Type = TransferObject.Type,
				Description = TransferObject.Description,
				Country = TransferObject.Country,

				Albums = TransferObject.Albums.Select(a=>a.ToDomain()).ToList()
			};
		}

		public static CrossCutting.TransferObjects.Artist ToTransferObject(this Domain.Artist Domain)
		{
			return new CrossCutting.TransferObjects.Artist
			{
				Id = Domain.Id,
				Name = Domain.Name,
				Type = Domain.Type,
				Description = Domain.Description,
				Country = Domain.Country,

				Albums = Domain.Albums.Select(a=>a.ToTranferObject()).ToList()
			};
		}
	}
}

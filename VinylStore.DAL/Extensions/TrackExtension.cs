using System;

namespace VinylStore.DAL.Extensions
{
	public static class TrackExtension
	{
		public static Entities.Track ToEntity (this CrossCutting.TransferObjects.Track TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException(nameof(TransferObject));

			return new Entities.Track
			{
				TrackId = TransferObject.Id,
				Title = TransferObject.Title,
				Number = TransferObject.Number,
				Position = TransferObject.Position,
				Length = TransferObject.Length,
			};
		}

		public static CrossCutting.TransferObjects.Track ToTransferObject (this Entities.Track Entity)
		{
			if (Entity is null)
				throw new ArgumentNullException(nameof(Entity));

			return new CrossCutting.TransferObjects.Track
			{
				Id = Entity.TrackId,
				Title = Entity.Title,
				Number = Entity.Number,
				Position = Entity.Position,
				Length = Entity.Length,

				AlbumId = Entity.AlbumId,
			};
		}
	}
}

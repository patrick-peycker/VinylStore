namespace VinylStore.BL.Extensions
{
	public static class TrackExtension
	{
		public static Domain.Track ToDomain(this CrossCutting.TransferObjects.Track TransferObject)
		{
			return new Domain.Track
			{
				Id = TransferObject.Id,
				Title = TransferObject.Title,
				Number = TransferObject.Number,
				Position = TransferObject.Position,
				Length = TransferObject.Length,

				AlbumId = TransferObject.AlbumId
			};
		}

		public static CrossCutting.TransferObjects.Track ToTransferObject(this Domain.Track Domain)
		{
			return new CrossCutting.TransferObjects.Track
			{
				Id = Domain.Id,
				Title = Domain.Title,
				Number = Domain.Number,
				Position = Domain.Position,
				Length = Domain.Length,

				AlbumId = Domain.AlbumId
			};
		}
	}
}

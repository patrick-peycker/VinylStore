namespace VinylStore.Web.Extensions
{
	public static class TrackExtension
	{
		public static Models.Track ToModel(this Api.TrackApi trackApi)
		{
			return new Models.Track
			{
				Id = trackApi.Id,
				Title = trackApi.Title,
				Number = trackApi.Number,
				Position = trackApi.Position,
				Length = trackApi.Length
			};
		}
	}
}

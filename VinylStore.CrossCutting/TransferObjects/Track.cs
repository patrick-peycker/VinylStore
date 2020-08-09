using System;

namespace VinylStore.CrossCutting.TransferObjects
{
	public class Track
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Number { get; set; }
		public int Position { get; set; }
		public DateTime Length { get; set; }

		public Guid AlbumId { get; set; }
	}
}

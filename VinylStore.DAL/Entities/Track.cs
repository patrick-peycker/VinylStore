using System;

namespace VinylStore.DAL.Entities
{
	public class Track
	{
		public Guid TrackId { get; set; }
		public string Title { get; set; }
		public string Number { get; set; }
		public int Position { get; set; }
		public int Length { get; set; }

		public Guid AlbumId { get; set; }
		public Album Album { get; set; }
	}
}

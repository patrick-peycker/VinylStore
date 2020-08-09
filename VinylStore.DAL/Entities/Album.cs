using System;
using System.Collections.Generic;

namespace VinylStore.DAL.Entities
{
	public class Album
	{
		public Guid AlbumId { get; set; }
		public string Title { get; set; }
		public DateTime Date { get; set; }
		public string Country { get; set; }
		public string Barcode { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public Guid ArtistId { get; set; }
		public Artist Artist { get; set; }

		public ICollection<Track> Tracks { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace VinylStore.BL.Domain
{
	public class Album
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public DateTime Date { get; set; }
		public string Country { get; set; }
		public string Barcode { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public Guid ArtistId { get; set; }

		public List<Track> Tracks { get; set; }
	}
}

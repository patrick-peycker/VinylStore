using System;
using System.Collections.Generic;

namespace VinylStore.DAL.Entities
{
	public class Artist
	{
		public Guid ArtistId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public string Country { get; set; }

		public ICollection<Album> Albums { get; set; }
	}
}

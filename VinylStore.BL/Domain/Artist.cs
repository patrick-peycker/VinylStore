using System;
using System.Collections.Generic;

namespace VinylStore.BL.Domain
{
	public class Artist
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public string Country { get; set; }

		public List<Album> Albums { get; set; }
	}
}
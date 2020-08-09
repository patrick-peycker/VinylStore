using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VinylStore.Web.Api
{
	public class GetAlbums
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Date { get; set; }
		public string Country { get; set; }
		public string Barcode { get; set; }

		[JsonProperty("track-count")]
		public int Track { get; set; }

		[JsonProperty("artist-credit")]
		public List<ArtistCredit> ArtistCredit { get; set; }
	}
}

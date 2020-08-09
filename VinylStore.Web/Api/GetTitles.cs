using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VinylStore.Web.Api
{
	public class GetTitles
	{
		[JsonProperty("id")]
		public Guid AlbumId { get; set; }

		public List<Media> Media { get; set; }
	}
}

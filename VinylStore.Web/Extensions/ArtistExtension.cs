using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylStore.Web.Extensions
{
	public static class ArtistExtension
	{
		public static Models.Artist ToModel (this Api.GetArtists artistApi)
		{
			return new Models.Artist
			{
				Id = artistApi.Id,
				Name = artistApi.Name,
				Type = artistApi.Type,
				Description = artistApi.Disambiguation,
				Country = artistApi.Area.Name,
				Score = artistApi.Score,
			};
		}
	}
}

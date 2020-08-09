using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylStore.Web.Extensions
{
	public static class AlbumExtension
	{
		public static Models.Album ToModel(this Api.GetAlbums albumApi)
		{
			DateTime date = new DateTime();

			if (DateTime.TryParse(albumApi.Date, out DateTime result))
				date = result;

			return new Models.Album
			{
				Id = albumApi.Id,
				Title = albumApi.Title,
				Barcode = albumApi.Barcode,
				Country = albumApi.Country,
				Track = albumApi.Track,
				Date = date,
			};
		}
	}
}

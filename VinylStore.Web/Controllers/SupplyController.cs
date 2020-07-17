using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VinylStore.Web.Models;

namespace VinylStore.Web.Controllers
{
	public class SupplyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GetArtists([FromBody] IEnumerable<Artist> artists)
		{
			return PartialView("_ArtistCard", artists.OrderByDescending(a => a.Score));
		}

		[HttpPost]
		public IActionResult GetAlbums([FromBody] IEnumerable<Album> albums)
		{
			return PartialView("_AlbumCard", albums.OrderBy(a => a.Date));
		}

		[HttpPost]
		public IActionResult CheckInStock(Album album)
		{
			return null;
		}
	}
}

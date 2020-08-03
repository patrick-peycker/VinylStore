using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VinylStore.Web.Models;

namespace VinylStore.Web.Controllers
{
	//[AllowAnonymous]
	//[Authorize(Roles ="Administrator")]

	public class SupplyController : Controller
	{
		private static IEnumerable<Artist> Artists { get; set; }
		private static Artist Artist { get; set; }

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GetArtists([FromBody] IEnumerable<Artist> artists)
		{
			Artists = artists;

			return PartialView("_ArtistCard", Artists.OrderByDescending(a => a.Score));
		}

		[HttpPost]
		public IActionResult GetAlbums([FromBody]IEnumerable<Album> albums)
		{
			return PartialView("_AlbumCard", albums);
		}

		[HttpPost]
		public IActionResult GetTitlesByAlbum(IEnumerable<Track> tracks)
		{
			return PartialView("_Titles", tracks);
		}
	}
}

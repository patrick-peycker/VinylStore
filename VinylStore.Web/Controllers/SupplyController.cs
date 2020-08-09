using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.Web.Api;
using VinylStore.Web.Extensions;
using VinylStore.Web.Models;

namespace VinylStore.Web.Controllers
{
	//[AllowAnonymous]
	//[Authorize(Roles ="Administrator")]

	public class SupplyController : Controller
	{
		private static List<Artist> Artists = new List<Artist>();
		private static Artist Artist = new Artist();
		//private readonly IManagerRole managerRole;

		//public SupplyController(IManagerRole managerRole)
		//{
		//	this.managerRole = managerRole;
		//}

		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult GetArtists([FromBody] IEnumerable<GetArtists> artists)
		{
			foreach (var artist in artists)
			{
				Artists.Add(artist.ToModel());
			}

			return PartialView("_ArtistCard", Artists.OrderByDescending(a => a.Score));
		}

		[HttpPost]
		public IActionResult GetAlbums([FromBody] IEnumerable<GetAlbums> albums)
		{
			var artistId = albums.FirstOrDefault().ArtistCredit.FirstOrDefault().Artist.Id;

			Artist = Artists.FirstOrDefault(a => a.Id == artistId);

			Artist.Albums = new List<Album>();

			foreach (var album in albums)
			{
				Artist.Albums.Add(album.ToModel());
			}

			return PartialView("_AlbumCard", Artist);
		}

		[HttpPost]
		public IActionResult GetTitlesByAlbum([FromBody] GetTitles titles)
		{
			var albumId = titles.AlbumId;

			Artist.Albums.FirstOrDefault(a => a.Id == albumId).Tracks = new List<Track>();

			foreach (var track in titles.Media.FirstOrDefault().Tracks)
			{
				Artist.Albums.FirstOrDefault(a => a.Id == albumId).Tracks.Add(track.ToModel());
			}

			return PartialView("_Titles", Artist.Albums.FirstOrDefault(a => a.Id == albumId).Tracks);
		}

		//[HttpGet]
		//public IActionResult CheckInStock(Guid albumId)
		//{
		//	if (managerRole.IsAlbumInStock(albumId))
		//	{
		//		return RedirectToAction("UpdateAlbum", managerRole.GetAlbum(albumId));
		//	}

		//	else
		//	{
		//		return RedirectToAction("AddAlbum", Artist.Albums.FirstOrDefault(a => a.Id == albumId));
		//	}
		//}

		[HttpGet]
		public IActionResult UpdateAlbum(Album album)
		{
			return View("EditAlbum", album);
		}

		[HttpGet]
		public IActionResult AddAlbum(Album album)
		{
			return View("EditAlbum", album);
		}
	}
}

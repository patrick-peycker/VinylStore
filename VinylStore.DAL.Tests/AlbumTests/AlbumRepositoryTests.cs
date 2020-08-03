using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Repositories;

namespace VinylStore.DAL.Tests.AlbumTests
{
	[TestClass]
	public class AlbumRepositoryTests
	{

		[TestMethod]
		public void Create_Retrieve()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				var albumRepository = new AlbumRepository(context);

				// Arrange - Create

				var artist = new Artist
				{
					ArtistId = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),
					Name = "Radiohead",
					Country = "GB",
					Type = "Group"
				};

				var album01 = new Album
				{
					Artist = artist,

					AlbumId = new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858"),
					Title = "OK Computer",
					Tracks = new List<Track>{
								new Track{
									TrackId= new Guid("9f9cf187-d6f9-437f-9d98-d59cdbd52757"),
									Title = "Paranoid Android",
									Position = 2,
									Number = "A2",
									Length = 383506
								}
							}
				};

				var album02 = new Album
				{
					Artist = artist,

					AlbumId = new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"),
					Title = "In Rainbows",
					Tracks = new List<Track> {
							new Track {
								TrackId = new Guid("90125ce1-1330-394c-b5ee-56f0cb2e1d50"),
								Title = "15 Step",
								Position = 1,
								Number = "A1",
								Length = 238120
							},
					}
				};

				// Act - Create

				albumRepository.Create(album01);
				albumRepository.Create(album02);
				context.SaveChanges();

				// Act - Retrieve
				var albumsToAssert = albumRepository.Retrieve();
				var album01ToAssert = albumRepository.Retrieve(new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858"));
				var album02ToAssert = albumRepository.Retrieve(new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"));

				var radioheadAlbumsToRetrieve = albumRepository.RetrieveAlbumsByArtist(new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"));

				// Assert
				Assert.AreEqual(2, albumsToAssert.Count());

				Assert.AreEqual("OK Computer", album01ToAssert.Title);
				Assert.AreEqual("15 Step", album02ToAssert.Tracks.FirstOrDefault().Title);

				Assert.AreEqual(2, radioheadAlbumsToRetrieve.Count());


				// Arrange - Update

				album01.Quantity = 10;
				album02.Price = 14.30m;

				// Act - Update

				albumRepository.Update(album01);
				albumRepository.Update(album02);
				context.SaveChanges();

				// Act - Retrieve

				albumsToAssert = albumRepository.Retrieve();
				album01ToAssert = albumRepository.Retrieve(new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858"));
				album02ToAssert = albumRepository.Retrieve(new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"));

				radioheadAlbumsToRetrieve = albumRepository.RetrieveAlbumsByArtist(new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"));


				// Assert

				Assert.AreEqual(2, albumsToAssert.Count());

				Assert.AreEqual("OK Computer", album01ToAssert.Title);
				Assert.AreEqual(10, album01ToAssert.Quantity);

				Assert.AreEqual("15 Step", album02ToAssert.Tracks.FirstOrDefault().Title);
				Assert.AreEqual(14.30m, album02ToAssert.Price);

				Assert.AreEqual(2, radioheadAlbumsToRetrieve.Count());

				Assert.IsTrue(albumRepository.IsExist(new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858")));
				Assert.IsFalse(albumRepository.IsExist(Guid.NewGuid()));

				Assert.AreEqual(10, albumRepository.RetrieveAlbumsInStock().FirstOrDefault(a => a.Title == "OK Computer").Quantity);
				Assert.IsNull(albumRepository.RetrieveAlbumsInStock().FirstOrDefault(a => a.Title == "In Rainbows"));
			}
		}
	}
}
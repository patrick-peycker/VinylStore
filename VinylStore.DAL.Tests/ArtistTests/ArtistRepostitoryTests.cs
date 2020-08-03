using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Repositories;

namespace VinylStore.DAL.Tests.ArtistsTests
{
	[TestClass]
	public class ArtistRepostitoryTests
	{
		[TestMethod]
		public void ShouldInsertInDb()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				// Arrange

				var artistTest = new Artist
				{
					ArtistId = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),
					Name = "Radiohead",
					Country = "GB",
					Type = "Group",
					Albums = new List<Album> {
						new Album {
							AlbumId = new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858"),
							Title="OK Computer",
							Tracks = new List<Track>{
								new Track{
									TrackId= new Guid("9f9cf187-d6f9-437f-9d98-d59cdbd52757"),
									Title = "Paranoid Android",
									Position = 2,
									Number = "A2",
									Length = 383506
								}
							}
							 },
					}
				};

				var artistRepository = new ArtistRepository(context);

				// Act - Create
				artistRepository.Create(artistTest);
				context.SaveChanges();

				// Act - Retrieve
				var artistsToAssert = artistRepository.Retrieve();
				var artistToAssert = artistRepository.Retrieve(new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"));

				// Assert
				Assert.AreEqual(1, artistsToAssert.Count());

				Assert.AreEqual("Radiohead", artistToAssert.Name);
				Assert.AreEqual("OK Computer", artistToAssert.Albums.FirstOrDefault().Title);
				Assert.AreEqual(2, artistToAssert.Albums.FirstOrDefault().Tracks.FirstOrDefault().Position);

				Assert.IsTrue(artistRepository.IsExist(new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711")));
				Assert.IsFalse(artistRepository.IsExist(Guid.NewGuid()));
			}
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VinylStore.CrossCutting.TransferObjects;
using VinylStore.DAL.Context;
using VinylStore.DAL.Repositories;

namespace VinylStore.DAL.Tests.AlbumTests
{
	[TestClass]
	public class Insert
	{
		[TestMethod]
		public void NullInserted_ThrowException()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				var albumRepository = new AlbumRepository(context);

				// Assert

				Assert.ThrowsException<ArgumentNullException>(() => albumRepository.Insert(null));
			}
		}

		[TestMethod]
		public void CorrectAlbumsInserted()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				var artistRepository = new ArtistRepository(context);
				var albumRepository = new AlbumRepository(context);

				// Arrange - Act
				var artist = new Artist
				{
					Id = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),
					Name = "Radiohead",
					Country = "GB",
					Type = "Group"
				};

				var artistAdded = artistRepository.Insert(artist);
				context.SaveChanges();


				var album01 = new Album
				{
					ArtistId = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),

					Id = new Guid("fe77a154-63da-4c0d-899c-3d8731e2d2c2"),
					Title = "A Moon Shaped Pool",

					Tracks = new List<Track>
							{
								new Track
								{
									Id = new Guid("c59df3ae-60b3-4b66-962c-7cc3c4484d20"),
									Title = "Burn the Witch",
									Position = 1,
									Number = "A1",
									Length = new DateTime(220000)
								}
							}
				};

				var resultAlbum01 = albumRepository.Insert(album01);
				context.SaveChanges();

				var album02 = new Album
				{
					ArtistId = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),

					Id = new Guid("9ae924e1-8a6c-4d61-acb6-6f004adf8559"),
					Title = "The Bends",

					Tracks = new List<Track>
					{
								new Track
								{
									Id = new Guid("49bb3701-1b75-4232-8999-ff5318adf676"),
									Title = "Planet Telex",
									Position = 1,
									Number = "A1",
									Length = new DateTime(259200)
								}
					}
				};

				var resultAlbum02 = albumRepository.Insert(album02);
				context.SaveChanges();

				// Assert
				Assert.IsNotNull(resultAlbum01);
				Assert.IsNotNull(resultAlbum02);

				Assert.AreEqual(new Guid("fe77a154-63da-4c0d-899c-3d8731e2d2c2"), resultAlbum01.Id);
				Assert.AreEqual(new Guid("9ae924e1-8a6c-4d61-acb6-6f004adf8559"), resultAlbum02.Id);

				Assert.AreEqual(1, resultAlbum01.Tracks.Count);
				Assert.AreEqual(1, resultAlbum02.Tracks.Count);

				Assert.AreEqual("Burn the Witch", resultAlbum01.Tracks.FirstOrDefault(t => t.Id == new Guid("c59df3ae-60b3-4b66-962c-7cc3c4484d20")).Title);

				Assert.AreEqual("Planet Telex", resultAlbum02.Tracks.FirstOrDefault(t => t.Id == new Guid("49bb3701-1b75-4232-8999-ff5318adf676")).Title);
			}
		}
	}
}

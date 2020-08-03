using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VinylStore.DAL.Context;
using VinylStore.DAL.Entities;
using VinylStore.DAL.Repositories;

namespace VinylStore.DAL.Tests.TrackTests
{
	[TestClass]
	public class TrackRepositoryTests
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

				var albumTest = new Album
				{
					AlbumId = new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"),
					Title = "In Rainbows",
				};

				var tracksListTest = new List<Track>
				{
					new Track
					{
						TrackId = new Guid("90125ce1-1330-394c-b5ee-56f0cb2e1d50"),
						Title= "15 Step",
						Length = 238120,
						Position= 1,
						Number= "A1",

						Album = albumTest
					},

					new Track
					{
						TrackId = new Guid("f10aa319-b5e4-3ba7-a9a7-e89da087ef29"),
						Title = "Bodysnatchers",
						Length = 242293,
						Position = 2,
						Number = "A2",

						Album = albumTest
					}
				};

				var trackRepository = new TrackRepository(context);

				// Act - Create

				trackRepository.CreateTracksList(tracksListTest);
				context.SaveChanges();

				// Assert - Retrieve
				Assert.AreEqual(2, trackRepository.RetrieveTracksByAlbums(new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5")).Count());
			}
		}
	}
}

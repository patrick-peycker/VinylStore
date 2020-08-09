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

namespace VinylStore.DAL.Tests.ArtistTests
{
	[TestClass]
	public class GetAllTests
	{
		[TestMethod]
		public void AddCorrectArtistThenRetrieveIt()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
					.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
					.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				var artistRepository = new ArtistRepository(context);

				// Arrange

				var artist = new Artist
				{
					Id = new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711"),
					Name = "Radiohead",
					Country = "GB",
					Type = "Group",

					Albums = new List<Album>
					{
						new Album
						{
							Id = new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858"),
							Title = "OK Computer",

							Tracks = new List<Track>
							{
								new Track
								{
									Id = new Guid("9f9cf187-d6f9-437f-9d98-d59cdbd52757"),
									Title = "Paranoid Android",
									Position = 2,
									Number = "A2",
									Length = new DateTime(383506)
								}
							}
						 },

						new Album
						{
							Id = new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"),
							Title = "In Rainbows",

							Tracks = new List<Track>
							{
								new Track
								{
									Id = new Guid("90125ce1-1330-394c-b5ee-56f0cb2e1d50"),
									Title = "15 Step",
									Position = 1,
									Number = "A1",
									Length = new DateTime(238120)
								}
							}
						}
					}
				};

				// Assert

				var artistAdded = artistRepository.Insert(artist);
				context.SaveChanges();

				var result = artistRepository.GetAll();

				// Assert
				Assert.IsNotNull(result);

				Assert.AreEqual(1, result.Count);

				Assert.AreEqual("Radiohead", result.FirstOrDefault(a => a.Id == new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711")).Name);

				Assert.AreEqual(2, result.FirstOrDefault(a => a.Id == new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711")).Albums.Count);

				Assert.AreEqual("Paranoid Android", result.FirstOrDefault(a => a.Id == new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711")).Albums.FirstOrDefault(a => a.Id == new Guid("943aa9da-7dc7-4a4a-a95e-2ffa707b6858")).Tracks.FirstOrDefault(t => t.Id == new Guid("9f9cf187-d6f9-437f-9d98-d59cdbd52757")).Title);

				Assert.AreEqual("15 Step", result.FirstOrDefault(a => a.Id == new Guid("a74b1b7f-71a5-4011-9441-d0b5e4122711")).Albums.FirstOrDefault(a => a.Id == new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5")).Tracks.FirstOrDefault(t => t.Id == new Guid("90125ce1-1330-394c-b5ee-56f0cb2e1d50")).Title);
			}
		}
	}
}
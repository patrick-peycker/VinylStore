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
	public class GetArtistsWithAlbumsInStockTests
	{
		[TestMethod]
		public void AddTwoArtistsThenRetrieveTheCorrectOne()
		{
			var options = new DbContextOptionsBuilder<VinylStoreDbContext>()
					.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
					.Options;

			using (var context = new VinylStoreDbContext(options))
			{
				var artistRepository = new ArtistRepository(context);

				// Arrange

				var artist01 = new Artist
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
							Quantity = 0,

							Tracks = new List<Track>
							{
								new Track
								{
									Id = new Guid("9f9cf187-d6f9-437f-9d98-d59cdbd52757"),
									Title = "Paranoid Android",
									Position = 2,
									Number = "A2",
									Length = new DateTime(383506),
								}
							}
						 },

						new Album
						{
							Id = new Guid("a58f4eb2-9829-37d5-b46c-e8163038e0f5"),
							Title = "In Rainbows",
							Quantity = 0,

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

				var artist01Added = artistRepository.Insert(artist01);
				context.SaveChanges();

				var artist02 = new Artist
				{
					Id = new Guid("5b11f4ce-a62d-471e-81fc-a69a8278c7da"),
					Name = "Nirvana",

					Albums = new List<Album>
					{
						new Album
						{
							Id = new Guid ("80d84b5b-62a0-42fb-bc97-10702e166b3b"),
							Title = "Nevermind",
							Quantity = 3
						}
					}
				};

				var artist02Added = artistRepository.Insert(artist02);
				context.SaveChanges();

				// Assert

				var result = artistRepository.GetArtistsWithAlbumsInStock();

				// Assert
				Assert.AreEqual(1, result.Count);
				Assert.AreEqual("Nevermind", result.FirstOrDefault(a => a.Id == new Guid("5b11f4ce-a62d-471e-81fc-a69a8278c7da")).Albums.FirstOrDefault(a=>a.Id == new Guid("80d84b5b-62a0-42fb-bc97-10702e166b3b")).Title);
			}
		}
	}
}

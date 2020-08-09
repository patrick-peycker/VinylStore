using System;

namespace VinylStore.Web.Api
{
	public class TrackApi
	{
		public Guid Id { get; set; }
		public string Number { get; set; }
		public int Position { get; set; }
		public int Length { get; set; }
		public string Title { get; set; }
	}
}

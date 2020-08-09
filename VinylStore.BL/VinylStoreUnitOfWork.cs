using System;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.DAL.Context;
using VinylStore.DAL.Repositories;

namespace VinylStore.BL
{
	public class VinylStoreUnitOfWork : IVinylStoreUnitOfWork
	{
		private readonly VinylStoreDbContext Context;
		public VinylStoreUnitOfWork(VinylStoreDbContext Context)
		{
			this.Context = Context ?? throw new ArgumentNullException(nameof(Context));
		}

		private IArtistRepository artistRepository;
		public IArtistRepository ArtistRepository => artistRepository = new ArtistRepository(Context);

		private IAlbumRepository albumRepository;
		public IAlbumRepository AlbumRepository => albumRepository = new AlbumRepository(Context);

		private ICartItemRepository cartItemRepository;
		public ICartItemRepository CartItemRepository => cartItemRepository = new CartItemRepository(Context);

		private IOrderRepository orderRepository;
		public IOrderRepository OrderRepository => orderRepository =  new OrderRepository(Context);

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public int SaveChanges()
		{
			return Context.SaveChanges();
		}
	}
}

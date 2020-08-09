namespace VinylStore.CrossCutting.Interfaces
{
	public interface IVinylStoreUnitOfWork : IUnitOfWork
	{
		IArtistRepository ArtistRepository { get; }
		IAlbumRepository AlbumRepository { get; }
		ICartItemRepository CartItemRepository { get; }
		IOrderRepository OrderRepository{ get; }
	}
}

using System.Collections.Generic;
using VinylStore.CrossCutting.TransferObjects;

namespace VinylStore.CrossCutting.Interfaces
{
	public interface ICartItemRepository : IRepository<CartItem>
	{
		//IEnumerable<CartItem> RetrieveByCartId(string CartId);

		//void DeleteAllByCartId(string CartId);
	}
}

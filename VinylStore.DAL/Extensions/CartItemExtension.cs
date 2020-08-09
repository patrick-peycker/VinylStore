using System;

namespace VinylStore.DAL.Extensions
{
	public static class CartItemExtension
	{
		public static Entities.CartItem ToEntity (this CrossCutting.TransferObjects.CartItem TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException(nameof(TransferObject));

			return new Entities.CartItem
			{
				CartItemId = TransferObject.Id,
				CartId = TransferObject.CartId,
				Amount = TransferObject.Amount,

				Album = TransferObject.Album?.ToEntity()
			};
		}

		public static CrossCutting.TransferObjects.CartItem ToTransferObject(this Entities.CartItem Entity)
		{
			if (Entity is null)
				throw new ArgumentNullException(nameof(Entity));

			return new CrossCutting.TransferObjects.CartItem
			{
				Id = Entity.CartItemId,
				CartId = Entity.CartId,
				Amount = Entity.Amount,

				Album = Entity.Album?.ToTransferObject()
			};
		}
	}
}

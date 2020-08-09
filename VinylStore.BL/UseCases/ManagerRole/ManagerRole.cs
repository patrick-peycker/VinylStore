using System;
using VinylStore.CrossCutting.Interfaces;

namespace VinylStore.BL.UseCases.ManagerRole
{
	public class ManagerRole : IManagerRole
	{
		private readonly IVinylStoreUnitOfWork iVinylStoreUnitOfWork;
		public ManagerRole(IVinylStoreUnitOfWork iVinylStoreUnitOfWork)
		{
			this.iVinylStoreUnitOfWork = iVinylStoreUnitOfWork ?? throw new ArgumentNullException(nameof(iVinylStoreUnitOfWork));
		}

		public bool IsAlbumInStock(Guid AlbumId)
		{
			try
			{
				return iVinylStoreUnitOfWork.AlbumRepository.IsExist(AlbumId);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool IsArtistInStock(Guid ArtistId)
		{
			try
			{
				return iVinylStoreUnitOfWork.ArtistRepository.IsExist(ArtistId);

			}

			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

using BG.Core.Context;
using BG.Core.Providers;
using BG.Core.Repositories;
using System;

namespace BG.Services.Image
{
	/// <summary>
	/// Partial image service implementation.
	/// </summary>
	public partial class ImageService : IImageService
	{
		private IWebContext _context = null;
		private IBlobsRepository _blobsRepository = null;
		private IStoragePathBuilder _storagePathBuilder = null;
		private IImageStorageProvider _imageStorageProvider = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageService(IWebContext context, IBlobsRepository blobsRepository, IStoragePathBuilder storagePathBuilder, IImageStorageProvider imageStorageProvider)
		{
			_context = context;
			_blobsRepository = blobsRepository;
			_storagePathBuilder = storagePathBuilder;
			_imageStorageProvider = imageStorageProvider;

			if (_storagePathBuilder == null)
				throw new ServiceException(nameof(ImageService), new ArgumentNullException(nameof(_storagePathBuilder)));

			if (_imageStorageProvider == null)
				throw new ServiceException(nameof(ImageService), new ArgumentNullException(nameof(_imageStorageProvider)));
		}
	}
}

using BG.Core.Entities;
using System;
using System.IO;

namespace BG.Services.Image
{
	/// <summary>
	/// Partial image service implementation.
	/// </summary>
	public partial class ImageService
	{
		/// <summary>
		/// Upload a new image.
		/// </summary>
		public Blob Upload(string imageName, string imageType, Stream imageStream)
		{
			int userId = _context.User.Id;
			var utcCreation = DateTime.UtcNow;

			var entity = new Blob()
			{
				Id = Guid.NewGuid(),
				UTCCreation = utcCreation,

				Type = imageType,
				Length = imageStream.Length,
				Extension = Path.GetExtension(imageName).Trim('.'),

				Container = _storagePathBuilder.BuildContainer(utcCreation),
			};

			_imageStorageProvider.Store(entity.Name, imageStream);

			_blobsRepository.Create(entity);

			return entity;
		}
	}
}

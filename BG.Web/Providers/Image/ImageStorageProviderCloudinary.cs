using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using BG.Core.Providers;
using System;
using System.IO;

namespace BG.Web.Providers
{
	/// <summary>
	/// Store and provide images from cloudinary service.
	/// </summary>
	public class ImageStorageProviderCloudinary : IImageStorageProvider
	{
		private string _defaultImagePlaceHolder = null;
		private Account _cloudinaryRemoteAccount = null;

		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageStorageProviderCloudinary(ImageStorageProviderParameters parameters)
		{
			var cloudName = parameters["cloudName"].ChangeType<string>();
			var cloudApiKey = parameters["cloudApiKey"].ChangeType<string>();
			var cloudApiSecret = parameters["cloudApiSecret"].ChangeType<string>();

			_defaultImagePlaceHolder = parameters["defaultImagePlaceHolder"].ChangeType<string>();

			ImageUploadMaxLengthInBytes = parameters.ImageUploadMaxLengthInBytes;

			if (cloudName.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(ImageStorageProviderCloudinary), new ArgumentNullException(nameof(cloudName)));

			if (cloudApiKey.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(ImageStorageProviderCloudinary), new ArgumentException(nameof(cloudApiKey)));

			if (cloudApiSecret.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(ImageStorageProviderCloudinary), new ArgumentException(nameof(cloudApiSecret)));

			_cloudinaryRemoteAccount = new Account(
				cloud: cloudName,
				apiKey: cloudApiKey,
				apiSecret: cloudApiSecret
			);
		}

		/// <summary>
		/// Clean virtual path.
		/// </summary>
		private string RemoveSlug(string virtualPath)
		{
			string blobData = Path.GetDirectoryName(virtualPath);

			return $"{blobData.Replace('\\', '/')}.{Path.GetExtension(virtualPath).Trim('.')}";
		}

		/// <summary>
		/// Gets the data stream for the specified image relative path.
		/// </summary>
		public Stream GetStream(string relativePath)
		{
			return Stream.Null;
		}

		/// <summary>
		/// Store the image stream data associated to the specified file name.
		/// </summary>
		public long Store(string originalFileName, Stream imageStream)
		{
			var cloudinaryClient = new Cloudinary(_cloudinaryRemoteAccount);

			var uploadParameters = new ImageUploadParams();

			uploadParameters.File = new FileDescription(originalFileName, imageStream);

			uploadParameters.PublicId = originalFileName.Replace(Path.GetExtension(originalFileName), string.Empty);

			var uploadResult = cloudinaryClient.Upload(uploadParameters);

			return uploadResult.Length;
		}

		/// <summary>
		/// Builds the relative url for the specified image. 
		/// </summary>
		public string BuildUrl(string virtualPath, int? width, int? height)
		{
			if (string.IsNullOrWhiteSpace(virtualPath))
				virtualPath = _defaultImagePlaceHolder;
			else
				virtualPath = RemoveSlug(virtualPath);

			var customer = new Cloudinary(_cloudinaryRemoteAccount);

			var transformation = new Transformation();

			if (width.HasValue)
				transformation = transformation.Width(width);

			if (height.HasValue)
				transformation = transformation.Height(height);

			transformation = transformation.Crop("fill").Gravity("faces:center").DefaultImage(_defaultImagePlaceHolder);

			return customer.Api.UrlImgUp.CSubDomain(true).UseRootPath(true).Transform(transformation).BuildUrl(virtualPath);
		}
	}
}

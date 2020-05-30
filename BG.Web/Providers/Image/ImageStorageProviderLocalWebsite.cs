using ImageResizer.FluentExtensions;
using BG.Core.Providers;
using System;
using System.IO;
using System.Web.Hosting;

namespace BG.Web.Providers
{
	/// <summary>
	/// Store and provide images from a local website file system directory.
	/// </summary>
	public class ImageStorageProviderLocalWebsite : IImageStorageProvider
	{
		private string _appDataFolder = null;
		private string _websiteImagesDirectory = null;

		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageStorageProviderLocalWebsite(ImageStorageProviderParameters parameters)
		{
			_appDataFolder = HostingEnvironment.MapPath("~/App_Data");
			_websiteImagesDirectory = parameters.GetValue<string>("imagesDirectory");

			ImageUploadMaxLengthInBytes = parameters.ImageUploadMaxLengthInBytes;

			if (_appDataFolder.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(ImageStorageProviderLocalWebsite), new ArgumentNullException(nameof(_appDataFolder)));

			if (_websiteImagesDirectory.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(ImageStorageProviderLocalWebsite), new ArgumentNullException(nameof(_websiteImagesDirectory)));

			if (!Directory.Exists(_appDataFolder))
				Directory.CreateDirectory(_appDataFolder);

			if (!Path.IsPathRooted(_websiteImagesDirectory))
				_websiteImagesDirectory = Path.Combine(_appDataFolder, _websiteImagesDirectory.Trim('~').Trim('\\').Trim('/'));

			if (!Directory.Exists(_websiteImagesDirectory))
				Directory.CreateDirectory(_websiteImagesDirectory);
		}

		/// <summary>
		/// Gets the data stream for the specified image relative path.
		/// </summary>
		public Stream GetStream(string relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath))
				throw new ArgumentException(nameof(ImageStorageProviderLocalWebsite), new ArgumentException(nameof(Stream), new ArgumentNullException(nameof(relativePath))));

			string imageBlobPath = Path.Combine(_websiteImagesDirectory, relativePath);

			if (!File.Exists(imageBlobPath))
				return Stream.Null;

			var stream = new MemoryStream();

			using (var fileStream = new FileStream(imageBlobPath, FileMode.Open, FileAccess.Read))
				fileStream.CopyTo(stream);

			stream.Position = 0;

			return stream;
		}

		/// <summary>
		/// Store the image stream data associated to the specified file name.
		/// </summary>
		public long Store(string internalFileName, Stream imageStream)
		{
			if (string.IsNullOrWhiteSpace(internalFileName))
				throw new ArgumentException(nameof(ImageStorageProviderLocalWebsite), new ArgumentException(nameof(Store), new ArgumentNullException(nameof(internalFileName))));

			var imageBlobPath = Path.Combine(_websiteImagesDirectory, internalFileName);

			Directory.CreateDirectory(Path.GetDirectoryName(imageBlobPath));

			using (imageStream)
			{
				using (var fStream = new FileStream(imageBlobPath, FileMode.Create, FileAccess.Write))
				{
					imageStream.CopyTo(fStream);

					return fStream.Length;
				}
			}
		}

		/// <summary>
		/// Builds the relative url for the specified image. 
		/// </summary>
		public string BuildUrl(string virtualPath, int? width, int? height)
		{
			if (string.IsNullOrWhiteSpace(virtualPath))
				throw new ArgumentException(nameof(ImageStorageProviderLocalWebsite), new ArgumentException(nameof(BuildUrl), new ArgumentNullException(nameof(virtualPath))));

			var builder = new ImageUrlBuilder();

			if (width.HasValue && height.HasValue)
			{
				builder.Resize(i => i.Dimensions(width.Value, height.Value));
			}
			else if (width.HasValue || height.HasValue)
			{
				if (width.HasValue)
					builder.Resize(i => i.Width(width.Value));

				if (height.HasValue)
					builder.Resize(i => i.Height(height.Value));
			}
			else
				builder.Cache(CacheOptions.Always);

			builder.Resize(i => i.Crop());

			return builder.BuildUrl(virtualPath);
		}
	}
}

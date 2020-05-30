using System.IO;

namespace BG.Core.Providers
{
	/// <summary>
	/// Image storage provider interface.
	/// </summary>
	public interface IImageStorageProvider
	{
		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		long ImageUploadMaxLengthInBytes { get; }

		/// <summary>
		/// Build the image url from the image virtual path.
		/// </summary>
		string BuildUrl(string virtualPath, int? width, int? height);

		/// <summary>
		/// Gets the image stream.
		/// </summary>
		Stream GetStream(string relativePath);

		/// <summary>
		/// Store the uploaded image.
		/// </summary>
		long Store(string originalFileName, Stream imageStream);
	}
}

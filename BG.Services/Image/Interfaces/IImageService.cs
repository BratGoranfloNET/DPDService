using BG.Core.Entities;
using System.IO;

namespace BG.Services.Image
{
	/// <summary>
	/// Image service interface.
	/// </summary>
	public interface IImageService
	{
		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		long ImageUploadMaxLengthInBytes { get; }

		/// <summary>
		/// Get the image stream from the specified virtual path.
		/// </summary>
		Stream GetStream(string virtualPath);

		/// <summary>
		/// Build url.
		/// </summary>
		string BuildUrl(string blobFileName, string seoLabel, int? width = null, int? height = null);

		/// <summary>
		/// Upload a new image.
		/// </summary>
		Blob Upload(string imageName, string imageType, Stream imageStream);
	}
}

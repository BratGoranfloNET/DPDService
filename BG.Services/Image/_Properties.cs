namespace BG.Services.Image
{
	/// <summary>
	/// Partial image service implementation.
	/// </summary>
	public partial class ImageService
	{
		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		public long ImageUploadMaxLengthInBytes => _imageStorageProvider.ImageUploadMaxLengthInBytes;
	}
}

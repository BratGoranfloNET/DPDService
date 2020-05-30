namespace BG.Services.Image
{
	/// <summary>
	/// Partial image service implementation.
	/// </summary>
	public partial class ImageService
	{
		/// <summary>
		/// Build the URL using the currently active image storage provider.
		/// </summary>
		public string BuildUrl(string blobFileName, string altText, int? width = null, int? height = null)
		{
			string vpath = string.Empty;

			if (altText.IsNullOrWhiteSpace())
				altText = "placeholder";

			if (string.IsNullOrWhiteSpace(blobFileName))
				vpath = _storagePathBuilder.BuildVirtualPathDefault(altText);
			else
				vpath = _storagePathBuilder.BuildVirtualPathEntity(blobFileName, altText);

			return _imageStorageProvider.BuildUrl(vpath, width, height);
		}
	}
}

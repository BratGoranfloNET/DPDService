using System.Collections.Generic;

namespace BG.Core.Providers
{
	/// <summary>
	/// Image storage provider parameters collection.
	/// </summary>
	public class ImageStorageProviderParameters : ProviderParameters
	{
		/// <summary>
		/// Gets the maximum size allowed for uploads.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageStorageProviderParameters(long imageUploadMaxLengthInBytes, Dictionary<string, object> parameters) : base(parameters)
		{
			ImageUploadMaxLengthInBytes = imageUploadMaxLengthInBytes;
		}
	}
}

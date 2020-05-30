using System;

namespace BG.Services
{
	public interface IStoragePathBuilder
	{
		string BuildContainer(DateTime utcCreateDate);
		string BuildRelativePath(string virtualPath);
		string BuildVirtualPathDefault(string blobSEOName);
		string BuildVirtualPathEntity(string blobName, string blobSEOName);
	}
}

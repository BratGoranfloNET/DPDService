using System;
using System.IO;

namespace BG.Services
{
	public class DefaultStoragePathBuilder : IStoragePathBuilder
	{
		private string BuildSlug(string blobName, string blobSEOName)
		{
			var blobExtension = Path.GetExtension(blobName).Trim('.');

			var slug = blobSEOName.ToSlug().WhenNullOrWhiteSpace("placeholder");

			return $"{slug}.{blobExtension}";
		}

		public string BuildContainer(DateTime utcCreateDate)
		{
			var y = utcCreateDate.ToString("yyyy");
			var m = utcCreateDate.ToString("MM");
			var d = utcCreateDate.ToString("dd");

            //return $"{y}/{m}/{d}";

            return $"{y}/{m}";

        }

		public string BuildRelativePath(string virtualPath)
		{
			var index = virtualPath.IndexOf("?");
			var queryIndex = index > 0 ? index : virtualPath.Length;

			var vpath = virtualPath.Substring(0, queryIndex);

			var blobData = Path.GetDirectoryName(vpath);
			var container = Path.GetDirectoryName(blobData);
			var blobName = $"{Path.GetFileName(blobData)}.{Path.GetExtension(vpath).Trim('.')}";

			return Path.Combine(container, blobName).Trim('\\');
		}

		public string BuildVirtualPathDefault(string blobSEOName)
		{
			string defaultName = "default";

			var slug = BuildSlug($"{defaultName}.jpg", blobSEOName);

			return $"/{defaultName}/{slug}";
		}

		public string BuildVirtualPathEntity(string blobName, string blobSEOName)
		{
			string pathContainer = Path.GetDirectoryName(blobName).Trim('/');
			string pathBlobId = Path.GetFileNameWithoutExtension(blobName);
			string slug = BuildSlug(blobName, blobSEOName);

			var vpath = Path.Combine(pathContainer, pathBlobId, slug).Trim('\\').Replace("\\", "/");

			return $"/{vpath}";
		}
	}
}

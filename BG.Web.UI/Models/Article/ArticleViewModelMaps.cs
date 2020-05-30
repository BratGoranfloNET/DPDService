using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contact view model mapper.
	/// </summary>
	public class ArticleViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<Article, ArticleViewModel>((source) =>
			{
				var result = new ArticleViewModel();

				result.InjectFrom(source);

				if (source.ImageBlob != null)
				{
					result.ImageBlobId = source.ImageBlob.Id;
					result.ImageBlobName = source.ImageBlob.Name;
				}

				return result;
			});
		}
	}
}

using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class CategoryViewModelMaps : IClassMapper
	{
		public void Configure()
		{
			Mapper.AddMap<Category, CategoryViewModel>((source) =>
			{
				var result = new CategoryViewModel();

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

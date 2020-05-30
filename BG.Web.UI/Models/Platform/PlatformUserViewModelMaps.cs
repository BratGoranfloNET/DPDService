using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using System.Linq;

namespace BG.Web.UI.Models
{	
	public class PlatformUserViewModelMaps : IClassMapper
	{
		
		public void Configure()
		{
			Mapper.AddMap<User, PlatformUserViewModel>((source, tag) =>
			{
				var result = new PlatformUserViewModel();
				var sourceTag = tag as PlatformUserViewModel;

				result.InjectFrom(source);
				
				if (sourceTag != null)
					result.InjectFrom(sourceTag);

				if (source.ImageBlob != null)
				{
					result.ImageBlobId = source.ImageBlob.Id;
					result.ImageBlobName = source.ImageBlob.Name;
				}

				
				result.Roles = source.Roles.Select(r => r.Role.ToString()).ToList();

				return result;
			});
		}
	}
}

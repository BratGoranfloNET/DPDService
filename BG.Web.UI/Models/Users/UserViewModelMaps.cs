using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using System.Linq;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User view model mappers.
	/// </summary>
	public class UserViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<User, UserViewModel>((source, tag) =>
			{
				var result = new UserViewModel();
				var sourceTag = tag as UserViewModel;

				result.InjectFrom(source);

				// When remapping after a postback model state error
				// the posted model will be passed to the mapper as a tag param.
				// here we override the entity data with the form posted information.
				if (sourceTag != null)
					result.InjectFrom(sourceTag);

				if (source.ImageBlob != null)
				{
					result.ImageBlobId = source.ImageBlob.Id;
					result.ImageBlobName = source.ImageBlob.Name;
				}

				// Map completion
				result.ProfileCompletion = Mapper.Map<ProfileCompletionViewModel>(source);

				// Map roles
				result.Roles = source.Roles.Select(r => r.Role.GetDisplayName()).ToList();

				return result;
			});
		}
	}
}

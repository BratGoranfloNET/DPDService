using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Profile completion view model mappers.
	/// </summary>
	public class ProfileCompletionViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<User, ProfileCompletionViewModel>((source) =>
			{
				var result = new ProfileCompletionViewModel();

				// Check social media
				var checkSocialMedia = false;

				checkSocialMedia |= !source.GitHubLink.IsNullOrWhiteSpace();
				checkSocialMedia |= !source.TwitterLink.IsNullOrWhiteSpace();
				checkSocialMedia |= !source.LinkedInLink.IsNullOrWhiteSpace();
				checkSocialMedia |= !source.FacebookLink.IsNullOrWhiteSpace();
				checkSocialMedia |= !source.InstagramLink.IsNullOrWhiteSpace();

				// Set completion items
				result.IsAccountCreated = true;
				result.IsImageUploaded = source.ImageBlobId.HasValue;
				result.IsBiographyUpdated = !source.Biography.IsNullOrWhiteSpace();
				result.IsSocialMediaUpdated = checkSocialMedia;

				return result;
			});
		}
	}
}

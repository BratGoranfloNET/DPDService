using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contact view model mapper.
	/// </summary>
	public class ContactViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<Contact, ContactViewModel>((source) =>
			{
				var result = new ContactViewModel();

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

using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Locations view model mapper.
	/// </summary>
	public class LocationsAddViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<Location, LocationViewModel>((source) =>
			{
				var result = new LocationViewModel();

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

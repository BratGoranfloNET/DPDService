using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class CalendarEventImageViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<Blob, CalendarEventImageViewModel>((source) =>
			{
				var result = new CalendarEventImageViewModel();
				result.InjectFrom(source);
				result.ImageBlobId = source.Id;
				result.ImageBlobName = source.Name;
				result.ImageLabel = string.Empty;
				result.ImageDescription = string.Empty;

				return result;
			});

			Mapper.AddMap<EventImage, CalendarEventImageViewModel>((source) =>
			{
				var result = new CalendarEventImageViewModel();

				result.InjectFrom(source);
				result.ImageBlobId = source.Id;
				result.ImageBlobName = source.Name;
				result.ImageLabel = source.Label;
				result.ImageDescription = source.Description;

				return result;
			});

			Mapper.AddMap<CalendarEventImageViewModel, EventImage>((source) =>
			{
				var result = new EventImage();
				result.InjectFrom(source);
				result.Id = source.ImageBlobId.Value;
				result.Label = source.ImageLabel;
				result.Description = source.ImageDescription;

				return result;
			});
		}
	}
}

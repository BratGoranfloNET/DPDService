using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class EventTrackingTypeAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<EventTrackingType, EventTrackingTypeViewModel>((source) =>
			{
				var result = new EventTrackingTypeViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<EventTrackingTypeViewModel, EventTrackingType>((source) =>
            {
                var result = new EventTrackingType();
                result.InjectFrom(source);
                return result;

            });
        }
	}
}

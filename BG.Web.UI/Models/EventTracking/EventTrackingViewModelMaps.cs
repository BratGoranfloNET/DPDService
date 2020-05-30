using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	public class EventTrackingAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<EventTracking, EventTrackingViewModel>((source) =>
			{
				var result = new EventTrackingViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<EventTrackingViewModel, EventTracking>((source) =>
            {
                var result = new EventTracking();
                result.InjectFrom(source);
                return result;
            });
        }
	}
}

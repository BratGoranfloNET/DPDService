using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	
	public class EventTrackingParameterAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<EventTrackingParameter, EventTrackingParameterViewModel>((source) =>
			{
				var result = new EventTrackingParameterViewModel();
				result.InjectFrom(source);               
                return result;
			});


            Mapper.AddMap<EventTrackingParameterViewModel, EventTrackingParameter>((source) =>
            {
                var result = new EventTrackingParameter();
                result.InjectFrom(source);
                return result;
            });

        }
	}
}

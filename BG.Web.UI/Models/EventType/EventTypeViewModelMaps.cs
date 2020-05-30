using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class EventTypeAddViewModelMaps : IClassMapper
	{
		public void Configure()
		{
			Mapper.AddMap<EventType, EventTypeViewModel>((source) =>
			{
				var result = new EventTypeViewModel();
				result.InjectFrom(source);
                return result;
			});



            Mapper.AddMap<EventTypeViewModel, EventType>((source) =>
            {
                var result = new EventType();
                result.InjectFrom(source);
                return result;

            });

        }
	}
}

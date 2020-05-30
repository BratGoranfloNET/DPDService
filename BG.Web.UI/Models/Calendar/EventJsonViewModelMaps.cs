using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using System;
using BG.Web.UI.ViewModels;

namespace BG.Web.UI.Models
{	
	public class EventJsonModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<Event, EventJsonModel>((source) =>
			{
				var result = new EventJsonModel();
				result.InjectFrom(source);
                long unixTimeStart = (long)(source.StartDate - new DateTime(1970, 1, 1)).TotalMilliseconds;
                long unixTimeEnd = (long)(source.EndDate - new DateTime(1970, 1, 1)).TotalMilliseconds;
                result.StartDate = unixTimeStart;
				result.EndDate = unixTimeEnd;

				return result;
			});



			Mapper.AddMap<EventJsonModel, Event>((source) =>
			{
				var result = new Event();
                return result;
			});
		}
	}
}

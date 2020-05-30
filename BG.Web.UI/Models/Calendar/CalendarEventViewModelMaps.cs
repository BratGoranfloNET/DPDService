using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using BG.Core.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event view model mapper.
	/// </summary>
	public class CalendarEventViewModelMaps : IClassMapper
	{
		/// <summary>
		/// Configure maps.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<Event, CalendarEventViewModel>((source) =>
			{
				var result = new CalendarEventViewModel();

				result.InjectFrom(source);

				result.Images = source.Images.Select(i => Mapper.Map<CalendarEventImageViewModel>(i)).ToList();

				result.StartDate = source.StartDate.Date;
				result.StartTime = source.StartDate.DateTime;

				result.EndDate = source.EndDate.Date;
				result.EndTime = source.EndDate.DateTime;

				return result;
			});

			Mapper.AddMap<CalendarEventViewModel, Event>((source) =>
			{
				var result = new Event();
				var locationsRepository = DependencyResolver.Current.GetService<ILocationsRepository>();

				result.InjectFrom(source);

				result.Images = source.Images.Select(i => Mapper.Map<EventImage>(i)).ToList();

				//var location = locationsRepository.GetById(source.LocationId.Value);

				//var locationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(location.TimeZoneId);

				// Create the base date
				var baseStart = new DateTime(
					source.StartDate.Value.Year,
					source.StartDate.Value.Month,
					source.StartDate.Value.Day,
					source.StartTime.Value.Hour,
					source.StartTime.Value.Minute,
					source.StartTime.Value.Second,
					DateTimeKind.Unspecified
				);

				// Build the localized instance from base
				result.StartDate = new DateTimeOffset(
					baseStart
					//locationTimeZone.GetUtcOffset(baseStart)
				);

				var baseEnd = new DateTime(
					source.EndDate.Value.Year,
					source.EndDate.Value.Month,
					source.EndDate.Value.Day,
					source.EndTime.Value.Hour,
					source.EndTime.Value.Minute,
					source.EndTime.Value.Second,
					DateTimeKind.Unspecified
				);

				result.EndDate = new DateTimeOffset(
					baseEnd
					//locationTimeZone.GetUtcOffset(baseEnd)
				);

				return result;
			});
		}
	}
}

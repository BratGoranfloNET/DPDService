using Dapper;
using BG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository
	{
		/// <summary>
		/// Build the entity object from the query results.
		/// </summary>
		//private Func<Event, Location, Production, EventType, Event> _eventMap = (@event, location, production, eventtype) =>
        private Func<Event, Location,  EventType, Event> _eventMap = (@event, location, eventtype) =>
        {

			@event.Location = location;
            // @event.Production = production;
            @event.EventType = eventtype;

            return @event;
		};

		/// <summary>
		/// From a multi result set, builds a single entity with its related data.
		/// </summary>
		private Event BuildEntity(SqlMapper.GridReader reader)
		{
			var entity = reader.Read(_eventMap).SingleOrDefault();

			if (entity != null)
				entity.Images = reader.Read<EventImage>().ToList();

			return entity;
		}

		/// <summary>
		/// From a multi result set, builds an entities collection with its related data.
		/// </summary>
		private IEnumerable<Event> BuildEntitiesList(SqlMapper.GridReader reader)
		{
			var entities = reader.Read(_eventMap).ToList();

			var imagesCollection = reader
				.Read<EventImage>()
				.GroupBy(eImg => eImg.EventId)
				.ToDictionary(group => group.Key, group => group.ToList());

			foreach (var entity in entities)
			{
				List<EventImage> images;

				if (!imagesCollection.TryGetValue(entity.Id, out images))
					images = new List<EventImage>();

				entity.Images = images;
			}

			return entities;
		}
	}
}

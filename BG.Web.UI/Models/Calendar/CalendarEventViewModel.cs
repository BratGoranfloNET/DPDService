using BG.Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event view model.
	/// </summary>
	public class CalendarEventViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the image file max length in bytes.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; set; } = 0;

		/// <summary>
		/// Gets or set the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		[Display(Name = "EventColor", ResourceType = typeof(CalendarResources))]
		public string Color { get; set; } = "#0088cc";

		/// <summary>
		/// Gets or sets the event name.
		/// </summary>
		[Display(Name = "EventName", ResourceType = typeof(CalendarResources))]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the event start date.
		/// </summary>
		[Display(Name = "EventStartDate", ResourceType = typeof(CalendarResources))]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Gets or sets the start time
		/// </summary>
		[DataType(DataType.Time)]
		[Display(Name = "EventStartTime", ResourceType = typeof(CalendarResources))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Gets or sets the event start date.
		/// </summary>
		[Display(Name = "EventEndDate", ResourceType = typeof(CalendarResources))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Gets or sets the end time
		/// </summary>
		[DataType(DataType.Time)]
		[Display(Name = "EventEndTime", ResourceType = typeof(CalendarResources))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Gets or sets the event location id.
		/// </summary>
		[Display(Name = "EventLocationId", ResourceType = typeof(CalendarResources))]
		public int? LocationId { get; set; }

		/// <summary>
		/// Gets or sets the location instance.
		/// </summary>
		public LocationViewModel Location { get; set; }

		/// <summary>
		/// Gets or sets the event description.
		/// </summary>
		[Display(Name = "EventDescription", ResourceType = typeof(CalendarResources))]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the available locations list.
		/// </summary>
		public SelectList Locations { get; set; }

		/// <summary>
		/// Gets or sets the event images.
		/// </summary>
		[Display(Name = "EventImages")]
		public List<CalendarEventImageViewModel> Images { get; set; } = new List<CalendarEventImageViewModel>();



        [Display(Name = "EventProductionId", ResourceType = typeof(CalendarResources))]
        public int? ProductionId { get; set; }
        //public ProductionViewModel Production { get; set; }
        public SelectList Productions { get; set; }



        [Display(Name = "EventTypeId", ResourceType = typeof(CalendarResources))]
        public int? EventTypeId { get; set; }
        public EventTypeViewModel EventType { get; set; }
        public SelectList EventTypes { get; set; }


        [Display(Name = "ФИО")]
        public string Fio { get; set; }


    }
}

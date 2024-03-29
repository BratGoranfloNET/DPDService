﻿using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Event statistics model.
	/// </summary>
	public class CalendarEventStatistics
	{
		/// <summary>
		/// Gets or sets the total registrations
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Gets or sets the latest registrations.
		/// </summary>
		public List<object> Latest { get; set; }

		/// <summary>
		/// Gets or sets weekly general purpose data.
		/// </summary>
		public List<object> WeeklyRegistrations { get; set; }
	}
}

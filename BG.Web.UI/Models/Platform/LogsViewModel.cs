using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Logs view model.
	/// </summary>
	public class LogsViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the log entries.
		/// </summary>
		public List<LogEntry> Entries { get; set; } = new List<LogEntry>();
	}
}

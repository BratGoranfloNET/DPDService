using System;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents a log entry on the system.
	/// </summary>
	public class LogEntry : IEntity
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the type label.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the properties content.
		/// </summary>
		public string Properties { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }
	}
}

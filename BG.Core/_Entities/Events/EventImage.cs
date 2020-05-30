namespace BG.Core.Entities
{
	/// <summary>
	/// Represents an event image entity.
	/// </summary>
	public class EventImage : Blob
	{
		public const int LabelMaxLength = 75;

		/// <summary>
		/// Gets or sets the parent event id.
		/// </summary>
		public int EventId { get; set; }

		/// <summary>
		/// Gets or set the ordered index.
		/// </summary>
		public int OrderIndex { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }
	}
}

using System;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents a blob entity.
	/// </summary>
	public class Blob : IEntity
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the blob mime type.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the blob length in bytes.
		/// </summary>
		public long Length { get; set; }

		/// <summary>
		/// Gets or sets the blob file extension.
		/// </summary>
		public string Extension { get; set; }

		/// <summary>
		/// Gets or sets the blob container (Folder).
		/// </summary>
		public string Container { get; set; }

		/// <summary>
		/// Gets the internal blob file name.
		/// </summary>
		public string Name => $@"{Container}/{Id}.{Extension}";
	}

}

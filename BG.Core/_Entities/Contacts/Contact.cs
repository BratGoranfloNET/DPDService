using System;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents a contact entity.
	/// </summary>
	public class Contact : IEntity
	{
		public const int NameMaxLength = 175;
		public const int EmailMaxLength = 175;
		public const int PhoneMaxLength = 25;

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }      

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the related image blob id.
		/// </summary>
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or sets the related image blob.
		/// </summary>
		public Blob ImageBlob { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		public ContactType Type { get; set; }
        public int IdOld { get; set; }
        public string FullName { get; set; }
        public string Inn { get; set; }
        public string Address { get; set; }
        public string SroNumberPasspotr { get; set; }
        public decimal Limit { get; set; }
        public string Profession { get; set; }
        public string ProfessionType { get; set; }
        public int ActiveFlag { get; set; }
        

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the birth date (UTC).
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the primary e-mail.
		/// </summary>
		public string Email1 { get; set; }

		/// <summary>
		/// Gets or sets the secondary e-mail.
		/// </summary>
		public string Email2 { get; set; }

		/// <summary>
		/// Gets or sets the primary phone.
		/// </summary>
		public string Phone1 { get; set; }

		/// <summary>
		/// Gets or sets the secondary phone.
		/// </summary>
		public string Phone2 { get; set; }

		/// <summary>
		/// Gets or sets the observation notes.
		/// </summary>
		public string Notes { get; set; }
	}
}

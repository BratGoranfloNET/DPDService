using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contact view model.
	/// </summary>
	public class ContactViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the image file max length in bytes.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; set; } = 0;

		/// <summary>
		/// Gets or set a flag indicating whether the contact type can be changed.
		/// </summary>
		public bool EnableTypeModification { get; set; } = true;

		/// <summary>
		/// Gets or set the view mode.
		/// </summary>
		public ContactViewModes ViewMode { get; set; } = ContactViewModes.Full;

		/// <summary>
		/// Gets or set the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or set the image blob id.
		/// </summary>
		[Display(Name = "ImageBlobId", ResourceType = typeof(ContactResources))]
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or set the image blob name.
		/// </summary>
		public string ImageBlobName { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Display(Name = "Name", ResourceType = typeof(ContactResources))]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		[Display(Name = "Type", ResourceType = typeof(ContactResources))]
		public ContactType Type { get; set; }


       public SelectList VizierTypeSelect { get; set; }

        // public ContactType FiltredEnumType { get; set; } 


        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        [Display(Name = "Gender", ResourceType = typeof(ContactResources))]
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		[Display(Name = "BirthDate", ResourceType = typeof(ContactResources))]
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the primary e-mail address.
		/// </summary>
		[Display(Name = "Email1", ResourceType = typeof(ContactResources))]
		public string Email1 { get; set; }

		/// <summary>
		/// Gets or sets the secondary e-mail address.
		/// </summary>
		[Display(Name = "Email2", ResourceType = typeof(ContactResources))]
		public string Email2 { get; set; }

		/// <summary>
		/// Gets or sets the primary phone.
		/// </summary>
		[Display(Name = "Phone1", ResourceType = typeof(ContactResources))]
		public string Phone1 { get; set; }

		/// <summary>
		/// Gets or sets the secondary phone.
		/// </summary>
		[Display(Name = "Phone2", ResourceType = typeof(ContactResources))]
		public string Phone2 { get; set; }

		/// <summary>
		/// Gets or sets the related observation notes.
		/// </summary>
		[Display(Name = "Notes", ResourceType = typeof(ContactResources))]
		public string Notes { get; set; }


        [Display(Name = "FullName", ResourceType = typeof(ContactResources))]
        public string FullName { get; set; }

        [Display(Name = "Inn", ResourceType = typeof(ContactResources))]
        public string Inn { get; set; }

        [Display(Name = "Address", ResourceType = typeof(ContactResources))]
        public string Address { get; set; }

        [Display(Name = "SroNumberPasspotr", ResourceType = typeof(ContactResources))]
        public string SroNumberPasspotr { get; set; }



        [Display(Name = "Limit", ResourceType = typeof(ContactResources))]
        public decimal Limit { get; set; }

        [Display(Name = "Profession", ResourceType = typeof(ContactResources))]
        public string Profession { get; set; }

        [Display(Name = "ProfessionType", ResourceType = typeof(ContactResources))]
        public string ProfessionType { get; set; }

        [Display(Name = "ActiveFlag", ResourceType = typeof(ContactResources))]
        public int ActiveFlag { get; set; }


    }
}

using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User view model.
	/// </summary>
	public class PlatformUserViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the realm.
		/// </summary>
		[Display(Name = "Realm", ResourceType = typeof(UserResources))]
		public Realm Realm { get; set; }

		/// <summary>
		/// Gets or set the name.
		/// </summary>
		[Display(Name = "Name", ResourceType = typeof(UserResources))]
		public string Name { get; set; }

		/// <summary>
		/// Gets or set the gender.
		/// </summary>
		[Display(Name = "Gender", ResourceType = typeof(UserResources))]
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or set the e-mail.
		/// </summary>
		[Display(Name = "Email", ResourceType = typeof(UserResources))]
		public string Email { get; set; }

		/// <summary>
		/// Gets or set the username.
		/// </summary>
		[Display(Name = "UserName", ResourceType = typeof(UserResources))]
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the image blob id.
		/// </summary>
		[Display(Name = "ImageBlobId", ResourceType = typeof(UserResources))]
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or set the image blob name.
		/// </summary>
		public string ImageBlobName { get; set; }

		/// <summary>
		/// Gets or sets the user roles list.
		/// </summary>
		public List<string> Roles { get; set; }

		/// <summary>
		/// Gets or set the available roles.
		/// </summary>
		public MultiSelectList RoleOptions { get; set; }


        public string AllRoles {get; set; }
    }
}

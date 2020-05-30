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
	public class UserViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the current tab.
		/// </summary>
		public UserAccountTabs CurrentTab { get; set; }

		/// <summary>
		/// Gets or sets the image upload max length (In bytes).
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; set; }

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
		/// Gets or set the github profile link.
		/// </summary>
		[Display(Name = "GitHubLink", ResourceType = typeof(UserResources))]
		public string GitHubLink { get; set; }

		/// <summary>
		/// Gets or set the twitter profile link.
		/// </summary>
		[Display(Name = "TwitterLink", ResourceType = typeof(UserResources))]
		public string TwitterLink { get; set; }

		/// <summary>
		/// Gets or set the linked in profile link.
		/// </summary>
		[Display(Name = "LinkedInLink", ResourceType = typeof(UserResources))]
		public string LinkedInLink { get; set; }

		/// <summary>
		/// Gets or set the facebook profile link.
		/// </summary>
		[Display(Name = "FacebookLink", ResourceType = typeof(UserResources))]
		public string FacebookLink { get; set; }

		/// <summary>
		/// Gets or set the instagram profile link.
		/// </summary>
		[Display(Name = "InstagramLink", ResourceType = typeof(UserResources))]
		public string InstagramLink { get; set; }

		/// <summary>
		/// Gets or sets the biography.
		/// </summary>
		[Display(Name = "Biography", ResourceType = typeof(UserResources))]
		public string Biography { get; set; }

		/// <summary>
		/// Gets or sets the current culture name.
		/// </summary>
		[Display(Name = "CurrentCultureId", ResourceType = typeof(UserResources))]
		public string CurrentCultureId { get; set; }

		/// <summary>
		/// Gets or sets the current UI culture name.
		/// </summary>
		[Display(Name = "CurrentUICultureId", ResourceType = typeof(UserResources))]
		public string CurrentUICultureId { get; set; }

		/// <summary>
		/// Gets or sets the time zone id.
		/// </summary>
		[Display(Name = "TimeZoneId", ResourceType = typeof(UserResources))]
		public string TimeZoneId { get; set; }

		/// <summary>
		/// Gets or sets the number of minutes before auto locking the screen.
		/// </summary>
		[Display(Name = "AutoLockScreenInMinutes", ResourceType = typeof(UserResources))]
		public byte AutoLockScreenInMinutes { get; set; }

		/// <summary>
		/// Gets or sets the current profile status message.
		/// </summary>
		[Display(Name = "StatusMessage", ResourceType = typeof(UserResources))]
		public string StatusMessage { get; set; }

		/// <summary>
		/// Gets or sets the status message update.
		/// </summary>
		public string StatusMessageUpdate { get; set; }

		/// <summary>
		/// Gets or sets the current cultures list (for numbers, currency and date formats).
		/// </summary>
		public SelectList CurrentCultures { get; set; }

		/// <summary>
		/// Gets or sets the current UI cultures list (For text translations).
		/// </summary>
		public SelectList CurrentUICultures { get; set; }

		/// <summary>
		/// Gets or sets the timezones.
		/// </summary>
		public SelectList TimeZones { get; set; }

		/// <summary>
		/// Gets or sets the user creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the user roles list.
		/// </summary>
		public List<string> Roles { get; set; }

		/// <summary>
		/// Gets or sets the profile completion percentage.
		/// </summary>
		public ProfileCompletionViewModel ProfileCompletion { get; set; }

		/// <summary>
		/// Gets or sets the latest activities.
		/// </summary>
		public Dictionary<string, List<Activity>> Activities { get; set; }
	}
}

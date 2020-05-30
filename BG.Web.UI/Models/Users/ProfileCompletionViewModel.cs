namespace BG.Web.UI.Models
{
	/// <summary>
	/// Simple profile completion view model.
	/// </summary>
	public class ProfileCompletionViewModel
	{
		/// <summary>
		/// Gets or sets the overall completion percentage.
		/// </summary>
		public double ProfileCompletionPercent
		{
			get
			{
				double totalSteps = 4;
				double totalCompleted = 0;

				if (IsAccountCreated)
					totalCompleted++;

				if (IsImageUploaded)
					totalCompleted++;

				if (IsSocialMediaUpdated)
					totalCompleted++;

				if (IsBiographyUpdated)
					totalCompleted++;

				return (totalCompleted / totalSteps) * 100;
			}
		}

		/// <summary>
		/// Gets or sets the account created status.
		/// </summary>
		public bool IsAccountCreated { get; set; }

		/// <summary>
		/// Gets or sets the profile picture updated status.
		/// </summary>
		public bool IsImageUploaded { get; set; }

		/// <summary>
		/// Gets or sets the social media status.
		/// </summary>
		public bool IsSocialMediaUpdated { get; set; }

		/// <summary>
		/// Gets or sets the biography status.
		/// </summary>
		public bool IsBiographyUpdated { get; set; }
	}
}

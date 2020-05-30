namespace BG.Core.Entities
{
	/// <summary>
	/// Represents an user claim entity.
	/// </summary>
	public class UserClaim : IEntity
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the realm.
		/// </summary>
		public Realm Realm { get; set; }

		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the claim type.
		/// </summary>
		public string ClaimType { get; set; }

		/// <summary>
		/// Gets or sets the claim value.
		/// </summary>
		public string ClaimValue { get; set; }
	}
}

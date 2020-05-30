using BG.Core.Entities;

namespace BG.Web.UI
{
	/// <summary>
	/// Overrides the default authorize attribute (Attention, the namespace should be kept as the base one).
	/// </summary>
	public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
	{
		/// <summary>
		/// Use enum flags for roles instead of strings.
		/// </summary>
		public new Role Roles
		{
			get { return base.Roles.ChangeType<Role>(); }
			set { base.Roles = value.ToString(); }
		}
	}
}

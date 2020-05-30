namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		private const string UsersInsert_Proc = "UsersInsert";
		private const string UsersSelect_Proc = "UsersSelect";
		private const string UsersUpdateIdentity_Proc = "UsersUpdateIdentity";
		private const string UsersUpdateProfile_Proc = "UsersUpdateProfile";
		private const string UsersDelete_Proc = "UsersDelete";
		private const string UserClaimsCleanup_Proc = "UserClaimsCleanup";
		private const string UserClaimsInsert_Proc = "UserClaimsInsert";
		private const string UserRolesCleanup_Proc = "UserRolesCleanup";
		private const string UserRolesInsert_Proc = "UserRolesInsert";
		private const string UsersSearch_Proc = "UsersSearch";
	}
}

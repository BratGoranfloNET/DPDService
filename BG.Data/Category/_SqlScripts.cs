namespace BG.Data
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class CategoryRepository
    {
		private const string CategoryInsert_Proc = "CategoryInsert";
		private const string CategorySelect_Proc = "CategorySelect";
		private const string CategoryUpdate_Proc = "CategoryUpdate";
		private const string CategoryDelete_Proc = "CategoryDelete";

        private const string CategoryParentsOnlySelect_Proc = "CategoryParentsOnlySelect";

        private const string CategoryChildesOnlySelect_Proc = "CategoryChildesOnlySelect";
        
    }
}

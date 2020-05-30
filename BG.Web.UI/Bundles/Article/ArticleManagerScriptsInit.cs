using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
    /// <summary>
    /// Specialized bundle.
    /// </summary>
    public class ArticleManagerScriptsInit : ScriptBundle
    {
        /// <summary>
        /// Gets the path that will reference this bundle on views.
        /// </summary>
        public const string BundleVirtualPath = "~/bundles/article/managearticles-scripts-init";

        /// <summary>
        /// Constructor method.
        /// </summary>
        public ArticleManagerScriptsInit() : base(BundleVirtualPath)
        {
            //Include("~/scripts/contacts/modal.js");
            //Include("~/scripts/ckeditor/ckeditor.js");
            //Include("~/scripts/ckfinder/ckfinder.js");
            Include("~/scripts/article/manager.js");

            Include("~/scripts/tag/modalselect.js");
          //Include("~/scripts/tag/modalselect-ajax.js");

        }
    }
}

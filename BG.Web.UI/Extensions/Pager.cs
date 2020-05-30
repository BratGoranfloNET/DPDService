using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BG.Data;


namespace BG.Web.UI.Extensions
{
    public partial class Pager : ViewUserControl<IPagination>
    {
        protected const int PageBuffer = 3;
        private string _currentAction = String.Empty;

        /// <summary>
        /// Gets the current action.
        /// </summary>
        /// <value>The current action.</value>
        public string CurrentAction
        {
            get
            {
                if (String.IsNullOrEmpty(_currentAction))
                    _currentAction = Html.ViewContext.RouteData.Values["action"] as string;

                return _currentAction;
            }
        }

        /// <summary>
        /// Gets the page URL.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        //public string GetPageUrl(int page)
        //{
        //    if (page < 1)
        //        throw new ArgumentOutOfRangeException("page", "'page' must be greater than or equal to 1");

        //    return Url.Action(
        //        this.ViewContext.RouteData.Values["action"] as string,
        //        new { page = page }
        //    );
        //}

        /// <summary>
        /// Gets the start and end page.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public static void GetStartAndEndPage(out int start, out int end, int PageCount, int PageNumber)
        {
            if (PageCount <= PageBuffer)
            {
                start = 1;
                end = PageCount;
            }
            else
            {
                start = Math.Max(PageNumber - PageBuffer, 1);
                end = Math.Min(PageNumber + PageBuffer, PageCount);
            }
        }
    }
}
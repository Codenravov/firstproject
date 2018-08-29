using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWebProject.Utilities.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString Paging(
            this HtmlHelper helper,
            int currentPage,
            int totalPage,
            string action,
            string controller,
            object routeValues,
            int maxPagesList = 3)
        {
            if (totalPage < 2)
            {
                return MvcHtmlString.Empty;
            }

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var ul = new TagBuilder("ul");
            int firstPage = currentPage - (int)(maxPagesList / 2);
            if (firstPage <= 1)
            {
                firstPage = 1;
            }
            else
            {
                if (totalPage - firstPage < maxPagesList)
                {
                    firstPage = totalPage - maxPagesList + 1;
                    if (firstPage <= 1)
                    {
                        firstPage = 1;
                    }
                }
            }

            int lastPage = firstPage + maxPagesList - 1;
            if (lastPage > totalPage)
            {
                lastPage = totalPage;
            }

            for (int i = firstPage; i <= lastPage; i++)
            {
                var anchor = new TagBuilder("a");
                anchor.SetInnerText(i.ToString());
                var routeValuesDictionary = new RouteValueDictionary(routeValues)
                {
                    { "Page", i }
                };
                anchor.MergeAttribute("href", urlHelper.Action(action, controller, routeValuesDictionary));
                var li = new TagBuilder("li") { InnerHtml = anchor.ToString() };
                if (i == currentPage)
                {
                    li.AddCssClass("active");
                }

                ul.InnerHtml += li.ToString();
            }

            return MvcHtmlString.Create(ul.ToString());
        }
    }
}
using System;
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
            object routeValues)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var ul = new TagBuilder("ul");

            int previous = currentPage - 1, next = currentPage + 1;
            if (totalPage < 2)
            {
                return MvcHtmlString.Empty;
            }

            if (totalPage < 3)
            {
                previous = 1;
                next = totalPage;
            }
            else
            {
                if (previous < 1)
                {
                    previous = 1;
                    next = 3;
                }

                if (next > totalPage)
                {
                    previous = currentPage - 2;
                    next = currentPage;
                }
            }

            for (int i = previous; i <= next; i++)
            {
                var anchor = new TagBuilder("a");
                anchor.SetInnerText(i.ToString());
                var routeValuesDictionary = new RouteValueDictionary(routeValues);
                routeValuesDictionary.Add("Page", i);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWebProject.Views.Helpers
{
    public static class Paginghelper
    {
        public static MvcHtmlString Paging(this HtmlHelper htmlHelper, int CurrentPage, int TotalPage, bool HasPreviousPage, bool HasNextPage,
        string action, string controller, object routeValues, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var ul = new TagBuilder("ul");
            var htmlAttributesDictionary = new RouteValueDictionary(htmlAttributes);
            htmlAttributesDictionary.Add("class", "pagination");
            ul.MergeAttributes(htmlAttributesDictionary);
            if (TotalPage < 2)
            {
                return MvcHtmlString.Empty;

            }
            int Previous = CurrentPage - 1, Next = CurrentPage + 1;
            if (TotalPage < 3) { Previous = 1; Next = TotalPage; }
            else
            {
                if (!HasPreviousPage) { Previous = 1; Next = 3; }
                if (!HasNextPage) { Previous = CurrentPage - 3; Next = CurrentPage; }
            }
            for (int i = Previous; i <= Next; i++)
            {
                var anchor = new TagBuilder("a");
                anchor.SetInnerText((i).ToString());
                var routeValuesDictionary = new RouteValueDictionary(routeValues);
                routeValuesDictionary.Add("page", i);
                anchor.MergeAttribute("href", urlHelper.Action(action, controller, routeValuesDictionary));
                var li = new TagBuilder("li") { InnerHtml = anchor.ToString(TagRenderMode.SelfClosing) };
                if (i == CurrentPage) li.AddCssClass("active");
                ul.InnerHtml += li.ToString(TagRenderMode.SelfClosing);
            }
            return MvcHtmlString.Create(ul.ToString());
        }
    }
}
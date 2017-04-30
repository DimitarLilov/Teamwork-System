using System.Text;
using System.Web.Mvc;
using TeamworkSystem.Models;

namespace TeamworkSystem.Extensions
{

    public static class HtmlHelperExtension
    {

        public static MvcHtmlString SocialMediaButton(this HtmlHelper helper, string url, string icon)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.AddCssClass("btn btn-default btn-circle " + icon);
            if (url != null)
            {
                builder.MergeAttribute("target", "_blank");
            }
            builder.MergeAttribute("href", url);

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string url, string @class, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass(@class);
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString Pages(this HtmlHelper helper, Pager pager, string url)
        {
            StringBuilder builder = new StringBuilder();
            if (pager.EndPage > 1)
            {
                builder.Append("<ul class=\"pagination\">");
                if (pager.CurrentPage > 1)
                {
                    builder.Append("<li class=\"prev\"><a href=\"");
                    builder.Append(url);
                    builder.Append("\" title=\"First\">First</a></li>");
                    builder.Append("<li>");
                    builder.Append("<li class=\"prev\"><a href=\"");
                    builder.Append(url + $"?page={pager.CurrentPage - 1}");
                    builder.Append("\" title=\"Previous\">Previous</a></li>");

                }
               
                for (var page = pager.StartPage; page <= pager.EndPage; page++)
                {
                    string active = null;
                    if (page == pager.CurrentPage)
                    {
                        active = "active";
                    }
                    builder.Append($"<li class=\"{active}\"><a href=\"");
                    builder.Append(url + $"?page={page}");
                    builder.Append($"\">{page}</a></li>");

                }

                if (pager.CurrentPage < pager.TotalPages)
                {
                    builder.Append("<li><a href=\"");
                    builder.Append(url + $"?page={pager.CurrentPage + 1}");
                    builder.Append("\" title=\"Next\">Next</a></li>");
                    builder.Append("<li>");
                    builder.Append("<li class=\"prev\"><a href=\"");
                    builder.Append(url + $"?page={pager.TotalPages}");
                    builder.Append("\" title=\"Last\">Last</a></li>");

                }
                
            }
            return new MvcHtmlString(builder.ToString());
        }

    }
}
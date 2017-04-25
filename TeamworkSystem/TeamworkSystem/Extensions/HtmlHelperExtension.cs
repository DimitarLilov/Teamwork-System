using System.Web.Mvc;

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

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
    }
}
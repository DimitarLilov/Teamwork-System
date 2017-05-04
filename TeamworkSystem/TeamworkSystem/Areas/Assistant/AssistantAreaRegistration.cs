using System.Web.Mvc;

namespace TeamworkSystem.Areas.Assistant
{
    public class AssistantAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Assistant";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
//            context.MapRoute(
//                "Assistant_default",
//                "Assistant/{controller}/{action}/{id}",
//                new { action = "Index", id = UrlParameter.Optional }
//            );
        }
    }
}
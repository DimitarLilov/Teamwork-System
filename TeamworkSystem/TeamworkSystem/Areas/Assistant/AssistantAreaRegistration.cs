namespace TeamworkSystem.Areas.Assistant
{
    using System.Web.Mvc;

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
        }
    }
}
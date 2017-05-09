namespace TeamworkSystem.Areas.Trainer
{
    using System.Web.Mvc;

    public class TrainerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Trainer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
        }
    }
}
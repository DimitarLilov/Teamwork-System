namespace TeamworkSystem.Models.ViewModels.Projects
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Repository { get; set; }

        public string LiveDemo { get; set; }

        public bool IsPublic { get; set; }

    }
}

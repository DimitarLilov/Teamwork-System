namespace TeamworkSystem.Models.EnitityModels
{
    public class ProjectCriteria
    {
        public int Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual Criteria Criteria { get; set; }

        public decimal Point { get; set; }

    }
}

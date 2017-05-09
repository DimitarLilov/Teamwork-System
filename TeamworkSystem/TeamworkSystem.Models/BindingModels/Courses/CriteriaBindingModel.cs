namespace TeamworkSystem.Models.BindingModels.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class CriteriaBindingModel
    {
        [Required]
        public int CriteriaId { get; set; }

        [Required]
        public decimal Point { get; set; }
    }
}

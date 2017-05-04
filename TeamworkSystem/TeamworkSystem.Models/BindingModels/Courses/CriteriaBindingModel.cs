using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Courses
{
    public class CriteriaBindingModel
    {
        [Required]
        public int  CriteriaId { get; set; }

        [Required]
        public decimal Point { get; set; }
    }
}

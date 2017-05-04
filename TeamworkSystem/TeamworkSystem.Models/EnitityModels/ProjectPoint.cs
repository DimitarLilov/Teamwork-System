using System.ComponentModel.DataAnnotations.Schema;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class ProjectPoint
    {
        public int Id { get; set; }

        public int CriteriaId { get; set; }

        [ForeignKey("CriteriaId")]
        public virtual Criteria Criteria { get; set; }

        public decimal Value { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public virtual Assistent PointAssistent { get; set; }

        public virtual Trainer PointTrainer { get; set; }

    }
}

﻿using System.Collections.Generic;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Assistent
    {
        public Assistent()
        {
            this.AssistingCourses = new HashSet<Course>();
            this.GradeProject = new HashSet<ProjectCriteria>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Course> AssistingCourses { get; set; }

        public virtual ICollection<ProjectCriteria> GradeProject { get; set; }

    }
}
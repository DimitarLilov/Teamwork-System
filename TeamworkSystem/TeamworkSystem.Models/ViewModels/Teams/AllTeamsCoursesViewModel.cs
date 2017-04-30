﻿using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Courses;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AllTeamsCoursesViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<CourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}

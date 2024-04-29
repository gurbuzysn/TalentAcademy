﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Common;

namespace TalentAcademy.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public List<Lesson> Lessons { get; set; } = new();
    }
}

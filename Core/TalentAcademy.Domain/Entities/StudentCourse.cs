﻿using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Domain.Entities
{
    public class StudentCourse
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

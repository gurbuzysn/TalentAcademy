﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Domain.Entities.Identitiy
{
    public class Student : AppUser
    {
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}

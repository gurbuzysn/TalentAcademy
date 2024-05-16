using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Dtos
{
    public class AdminDashboardDto
    {
        public int AdminsCount { get; set; }
        public int StudentsCount { get; set; }
        public int CoursesCount { get; set; }
    }
}

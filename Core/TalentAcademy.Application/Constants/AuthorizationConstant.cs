using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Constants
{
    public static class AuthorizationConstant
    {
        public const string ADMIN_FIRSTNAME = "Yasin";
        public const string ADMIN_LASTNAME = "Gürbüz";
        public const string ADMIN_USERNAME = "yasin.gurbuz@talentacademy.com";
        public const string ADMIN_PASSWORD = "Admin123*";
        public const string ADMIN_PHONE = "5389452293";

        public const string STUDENT_FIRSTNAME = "Kerem";
        public const string STUDENT_LASTNAME = "Gürbüz";
        public const string STUDENT_USERNAME = "kerem.gurbuz@talentacademy.com";
        public const string STUDENT_PASSWORD = "Student123*";
        public const string STUDENT_PHONE = "5556667788";


        public static class Roles
        {
            public const string ADMIN = "Admin";
            public const string TRAINER = "Trainer";
            public const string STUDENT = "Student";
        }
    }
}

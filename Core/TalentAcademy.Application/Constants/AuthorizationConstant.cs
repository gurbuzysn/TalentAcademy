﻿using System;
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

        public const string STUDENT_FIRSTNAME = "Aslı";
        public const string STUDENT_LASTNAME = "Çınar";
        public const string STUDENT_USERNAME = "asli.cinar@talentacademy.com";
        public const string STUDENT_PASSWORD = "Student123*";

        public static class Roles
        {
            public const string ADMINISTRATOR = "Admin";
            public const string STUDENT = "Student";
        }
    }
}
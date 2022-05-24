﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Student
    {
        public string FIO
        {
            get
            {
                if (Middlename != null)
                    return $"{Surname} {Firstname} {Middlename}";
                else
                    return $"{Surname} {Firstname}";
            }
        }

        public string GroupName => Group.Name;
        public string SpecializationName => $"{Specialization.Code} {Specialization.Name}";
        public string GenderName => Gender.Name;
        public string BirthdateNoTime => Birthdate.Value.ToShortDateString();
    }
}

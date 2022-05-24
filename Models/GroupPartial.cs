using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Group
    {
        public string SpecializationName => $"{Specialization.Code} {Specialization.Name}";
        public string DepartmentName => $"{Department.Name}";
        public int StudentCount => Students.Count;
        public string CuratorName => $"{User.FIO}";
    }
}

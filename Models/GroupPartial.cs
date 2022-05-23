using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Group
    {
        public string SpecializationName { get { return $"{Specialization.Code} {Specialization.Name}"; } }
        public string DepartmentName { get { return $"{Department.Name}"; } }
        public int StudentCount { get { return Students.Count; } }
        public string CuratorName { get { return $"{User.FIO}"; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class GraduateWork
    {
        public string StudentFIO => Student.FIO;
        public string GroupName => Student.GroupName;
        public string GWKTypeName => GraduateWorkType.Name;
        public string ProtectDateNoTime => ProtectDate.ToShortDateString();
        public string QualificationName => Qualification.Name;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class CourseWork
    {
        public string StudentFIO => Student.FIO;
        public string GroupName => Student.GroupName;
        public string FinishDateNoTime => FinishDate.ToShortDateString();
        public string DisciplineName => Discipline.IndexAndName;
    }
}

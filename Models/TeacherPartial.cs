using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Teacher
    {
        public string FIO { get { return $"{Surname} {Name} {Middlename}"; } }
        public string GenderName { get { return $"{Gender.Name}"; } }
    }
}

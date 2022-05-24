using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Teacher
    {
        public string FIO
        {
            get
            {
                if (Middlename != null)
                    return $"{Surname} {Name} {Middlename}";
                else
                    return $"{Surname} {Name}";
            }
        }
        public string GenderName => $"{Gender.Name}";
    }
}

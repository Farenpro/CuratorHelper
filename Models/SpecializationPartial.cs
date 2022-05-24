using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Specialization
    {
        public string SpecializationCodeName => $"{Code} {Name}";
    }
}

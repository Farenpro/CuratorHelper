using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
  public partial class PracticeName
    {
        public string PracticeNameStr
        {
            get
            {
                if (PracticeIndex != null)
                    return $"{PracticeIndex.Name} {Name}";
                else
                    return $"{Name}";
            }
        }
    }
}

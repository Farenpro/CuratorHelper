using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class PenAndInc
    {
        public string TypeName => PenAndIncType.Name;
        public string OrderInfo => $"№ {Order.ID} | Дата: {Order.DateNoTime}";
    }
}

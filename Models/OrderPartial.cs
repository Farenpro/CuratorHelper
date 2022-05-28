using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuratorHelper.Models
{
    public partial class Order
    {
        public string StudentFIO => Student.FIO;
        public string DateNoTime => Date.ToString("dd.MM.yyyy");
        public string OrderTypeName => OrderType.Name;
        public string FullInfo => $"№ {ID} | Дата: {DateNoTime}";
    }
}

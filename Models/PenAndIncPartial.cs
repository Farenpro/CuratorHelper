namespace CuratorHelper.Models
{
    public partial class PenAndInc
    {
        public string TypeName => PenAndIncType.Name;
        public string OrderInfo => $"№ {Order.ID} | Дата: {Order.DateNoTime}";
    }
}

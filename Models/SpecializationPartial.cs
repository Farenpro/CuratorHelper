namespace CuratorHelper.Models
{
    public partial class Specialization
    {
        public string SpecializationCodeName => $"{Code} {Name}";
    }
}

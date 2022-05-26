namespace CuratorHelper.Models
{
    public partial class Discipline
    {
        public string ObjectName => Object.Name;
        public string IndexName => DisciplineIndex.Name;
        public string IndexAndName => $"{IndexName} {ObjectName}";
    }
}

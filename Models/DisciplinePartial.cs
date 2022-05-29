namespace CuratorHelper.Models
{
    public partial class Discipline
    {
        public string ObjectName => Object.Name;
        public string IndexName
        {
            get
            {
                if (DisciplineIndex != null)
                    return DisciplineIndex.Name;
                else
                    return null;
            }
        }

        public string IndexAndName
        {
            get
            {
                if (IndexName != null)
                    return $"{IndexName} {ObjectName}";
                else
                    return ObjectName;
            }
        }
    }
}

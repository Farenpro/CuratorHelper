namespace CuratorHelper.Models
{
    public partial class Group
    {
        public string SpecializationName => $"{Specialization.Code} {Specialization.Name}";
        public string DepartmentName => $"{Department.Name}";
        public int StudentCount => Students.Count;
        public string CuratorName => $"{User.FIO}";
    }
}

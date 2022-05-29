namespace CuratorHelper.Models
{
    public partial class CourseWork
    {
        public string StudentFIO => Student.FIO;
        public string GroupName => Student.GroupName;
        public string FinishDateNoTime => FinishDate.ToShortDateString();
        public string DisciplineName => Discipline.IndexAndName;
    }
}

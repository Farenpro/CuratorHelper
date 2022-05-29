namespace CuratorHelper.Models
{
    public partial class DemoExam
    {
        public string StudentFIO => Student.FIO;
        public string GroupName => Student.GroupName;
        public string DemoName => DemoExamName.Name;
    }
}

namespace CuratorHelper.Models
{
    public partial class Practice
    {
        public string StudentFIO => Student.FIO;
        public string GroupName => Student.GroupName;
        public string PracticeNameStr
        {
            get
            {
                if (PracticeName.PracticeIndex != null)
                    return $"{PracticeName.PracticeIndex} {PracticeName.Name}";
                else
                    return PracticeName.Name;
            }
        } 
    }
}

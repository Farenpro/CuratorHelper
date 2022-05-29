namespace CuratorHelper.Models
{
    public partial class PracticeName
    {
        public string PracticeNameStr
        {
            get
            {
                if (PracticeIndex != null)
                    return $"{PracticeIndex.Name} {Name}";
                else
                    return $"{Name}";
            }
        }
    }
}

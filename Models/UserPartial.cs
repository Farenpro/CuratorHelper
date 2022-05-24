namespace CuratorHelper.Models
{
    public partial class User
    {
        public string FI => $"{Surname} {Name}";
        public string FIO
        {
            get
            {
                if (Middlename != null)
                    return $"{Surname} {Name} {Middlename}";
                else
                    return $"{Surname} {Name}";
            }
        }
        public string RoleName => Role.Name;
    }
}

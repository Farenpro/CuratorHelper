namespace CuratorHelper.Models
{
    public partial class User
    {
        public string FI { get { return $"{Surname} {Name}"; } }
        public string FIO { get { return $"{Surname} {Name} {Middlename}"; } }
        public string RoleName { get { return Role.Name; } }
    }
}

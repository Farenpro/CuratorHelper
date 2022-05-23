//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuratorHelper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Groups = new HashSet<Group>();
        }
    
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int GenderID { get; set; }
    
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
        public virtual Role Role { get; set; }
    }
}

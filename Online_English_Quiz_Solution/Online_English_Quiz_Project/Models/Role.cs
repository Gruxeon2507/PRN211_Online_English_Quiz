using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class Role
    {
        public Role()
        {
            Usernames = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<User> Usernames { get; set; }
    }
}

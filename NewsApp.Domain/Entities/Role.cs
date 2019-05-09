using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Journalist> Journalists { get; set; } = new List<Journalist>();
    }
}

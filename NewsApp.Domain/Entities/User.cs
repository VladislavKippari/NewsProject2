using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
  public  class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

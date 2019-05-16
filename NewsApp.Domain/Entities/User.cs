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
            Articles = new HashSet<Article>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

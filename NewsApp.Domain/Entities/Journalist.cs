using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
   public class Journalist
    {
        public Journalist()
        {
            Articles = new HashSet<Article>();
        }
        public int JournalistId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Biography { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

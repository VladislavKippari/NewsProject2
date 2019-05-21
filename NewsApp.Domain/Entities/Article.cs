using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
    public class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime CreatingDate { get; set; }
        public string ArticleText { get; set; }
        public string Image { get; set; }
        public User Journalist { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Category Category { get; set; }
      
    }
}

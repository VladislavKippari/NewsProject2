using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int Title { get; set; }
        public DateTime CreatingDate { get; set; }
        public string ArticleText { get; set; }
        public byte[] Image { get; set; }
       
        public Journalist Journalist { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Category> Categorys { get; set; }
    }
}

using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
            Comments = new HashSet<Comment>();
        }
        
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public string Image { get; set; }
        public Journalist Journalist { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Category Category { get; set; }
    }
}

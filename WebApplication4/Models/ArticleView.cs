using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ArticleView
    {
        public ArticleView()
        {
            Comments = new HashSet<Comment>();
        }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime CreatingDate { get; set; }
        public string ArticleText { get; set; }
        public string Image { get; set; }
        public Journalist Journalist { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Category Category { get; set; }
    }
}

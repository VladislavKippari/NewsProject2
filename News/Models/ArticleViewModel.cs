using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime CreatingDate { get; set; }
        public string ArticleText { get; set; }
        public string Image { get; set; }
       
        public ICollection<Comment> Comments { get; set; }
     
        public int CategoryId { get; set; }
        public int JournalistUserId { get; set; }
        public string CategoryName { get; set; }
        public string JournalistName { get; set; }
    }
}

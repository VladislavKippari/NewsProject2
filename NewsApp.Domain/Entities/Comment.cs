using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
   public class Comment
    {
        public int CommentId { get; set; }
    
        public string CommentText { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
    }
}

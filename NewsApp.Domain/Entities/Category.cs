using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
  public  class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

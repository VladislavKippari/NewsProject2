using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Entities
{
  public  class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Article Article { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class CategoryViewModel
    {

        public int SelectedCategoryId { get; set; }
        public SelectList CategoryName { get; set; }
       

    }
}

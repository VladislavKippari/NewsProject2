using Microsoft.AspNetCore.Http;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class CheckRole
    {
        public bool ShowReports { get; set; }
        public bool ShowDashboard { get; set; }
        public bool ShowAdmin { get; set; }

    }
}

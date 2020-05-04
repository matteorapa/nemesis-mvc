﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Report
    {
        public IdentityUser User { get; set; }
        public int ReportId { get; set; }
        public string HazardLocation { get; set; }
        public DateTime DateOfReport { get; set; }
        public DateTime HazardDate { get; set; }
        public string HazardType { get; set; }
        public string HazardDescription { get; set; }
        public string ReporterEmail { get; set; }
        public string ReporterPhone { get; set; }
        public string ReportStatus { get; set; }
        public string ImageUrl { get; set; }
        public int Upvotes { get; set; }

        //One-to-Many relationship with User - EF Core Conventions
        //public User User { get; set; } //Reference Property
    }
}

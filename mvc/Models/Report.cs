﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Report
    {
        public ApplicationUser User { get; set; }
        public int ReportId { get; set; }
        public string HazardLocation { get; set; }

        public double LatitudeMarker { get; set; }
        public double LongitudeMarker { get; set; }
        public DateTime DateOfReport { get; set; }
        public DateTime HazardDate { get; set; }
        public string HazardType { get; set; }
        public string HazardDescription { get; set; }
        public string ReporterEmail { get; set; }
        public string ReporterPhone { get; set; }
        public string ReportStatus { get; set; }
        public string ImageUrl { get; set; }

        //One-to-Many (Report to Upvotes) relationship with Upvote - EF Core Convention 4   
        public ICollection<Upvote> Upvotes { get; set; }
    }
}

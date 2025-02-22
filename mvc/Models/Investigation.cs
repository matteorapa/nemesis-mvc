﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Investigation
    {
        public int InvestigationId { get; set; } //Primary Key
        public DateTime DateOfAction { get; set; }
        public ApplicationUser User { get; set; }
        public string InvestigatorEmail { get; set; }
        public string InvestigatorPhone { get; set; }
        public string InvDescription{ get; set; }

        //One-to-One relationship with Report - EF Core Conventions
        public int ReportId { get; set; } //FK Property
        public Report Report { get; set; } //Reference Property

    }
}

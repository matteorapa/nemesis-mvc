﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{

    public interface IReportRepository
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int reportId);
        //Report EditReportById(int reportId);
        //Report DeleteReportById(int reportId);

    }
}

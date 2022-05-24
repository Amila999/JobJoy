using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJoy.Models
{
    public class Job
    {
        public string job_category { get; set; }
        public string job_location { get; set; }
        public string job_date { get; set; }
        public string job_time { get; set; }
        public string job_description { get; set; }
        public string job_budget { get; set; }
    }
}
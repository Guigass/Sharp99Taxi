using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class Job
    {
        public string apiTaxiJobId { get; set; }
        public string receiptId { get; set; }
        public Company company { get; set; }
        public Employee employee { get; set; }
        public CostCenter costCenter { get; set; }
        public Project project { get; set; }
        public int fare { get; set; }
        public string note { get; set; }
        public int odometer { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
        public Driver driver { get; set; }
        public string city { get; set; }
        public string callPlatform { get; set; }
        public string requesterName { get; set; }
        public string taxiCategoryName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class Ride
    {
        public int employeeID { get; set; }
        public From from { get; set; }
        public string phoneNumber { get; set; }
        public int costCenterID { get; set; }
        public string categoryID { get; set; }
        public To to { get; set; }
        public string notes { get; set; }
        public int projectID { get; set; }
        public List<string> optionals { get; set; }
        public string status { get; set; }
        public Running running { get; set; }
    }
}

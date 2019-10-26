using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class Running
    {
        public string rideID { get; set; }
        public string jobID { get; set; }
        public Driver driver { get; set; }
        public Route route { get; set; }
        public bool smsStartedSent { get; set; }
        public bool smsDriverCanceledSent { get; set; }
    }
}

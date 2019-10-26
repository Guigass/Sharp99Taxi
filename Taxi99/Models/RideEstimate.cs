using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class RideEstimate
    {
        public Category category { get; set; }
        public Estimate estimate { get; set; }
        public List<Optional> optionals { get; set; }
    }
}

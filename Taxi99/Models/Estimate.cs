using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class Estimate
    {
        public int lowerFare { get; set; }
        public int upperFare { get; set; }
        public string currencyCode { get; set; }
        public string fareText { get; set; }
        public string fareTextComplement { get; set; }
    }
}

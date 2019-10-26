using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class CostCenter
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool enabled { get; set; }
        public Company company { get; set; }
    }
}

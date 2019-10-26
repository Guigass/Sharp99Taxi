using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi99.Models
{
    public class Employee
    {
        public string name { get; set; }
        public Phone phone { get; set; }
        public string email { get; set; }
        public Guid companyId { get; set; }
        public Company company { get; set; }
        public string nationalId { get; set; }
        public bool enabled { get; set; }
        public int externalId { get; set; }
        public int supervisorId { get; set; }
        public string[] categories { get; set; }
        public int id { get; set; }
    }
}

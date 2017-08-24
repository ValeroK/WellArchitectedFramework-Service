using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WellArchitectedServices.Data
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Observable { get; set; }
        public int? ApiFirst { get; set; }
        public int? CiCdSupport { get; set; }
        public int? Tested { get; set; }
        public int? WellDesignedDeveloped { get; set; }
        public int? Measured { get; set; }
        public int? Secured { get; set; }
        public int? EcoSystemMember { get; set; }
        public int? MultiTenantSupport { get; set; }
        public int? Scalable { get; set; }
        public int? Resilient { get; set; }
        public int? Knowledge { get; set; }
        public int? Mastery { get; set; }
        public int? DevEcoSys { get; set; }
        public int? WellSeparated { get; set; }
        public DateTime Updated { get; set; }
    }
}
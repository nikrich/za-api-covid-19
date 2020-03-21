using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class HospitalsPublicModel
    {
        public string Name { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string Category { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
    }
}

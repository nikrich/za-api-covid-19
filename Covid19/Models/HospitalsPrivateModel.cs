using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class HospitalsPrivateModel
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string Province { get; set; }
    }
}

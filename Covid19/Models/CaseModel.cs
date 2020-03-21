using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class CaseModel
    {
        public int CaseId { get; set; }
        public DateTime Date { get; set; }
        public string DatePlain { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string GeoSubdivisions { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string TransmissionType { get; set; }
    }
}

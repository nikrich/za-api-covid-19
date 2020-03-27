using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class TestsModel
    {
        public DateTime Date { get; set; }
        public string DatePlain { get; set; }
        public int CmulativeTests { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int ScannedTravellers { get; set; }
        public int PassengersElevatedTemperature { get; set; }
        public int CovidSuspectedCriteria { get; set; }
    }
}

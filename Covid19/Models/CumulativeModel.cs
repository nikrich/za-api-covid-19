using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class CumulativeModel
    {     
        public DateTime Date { get; set; }
        public string DatePlain { get; set; }
        public int EasternCape { get; set; }
        public int FreeState { get; set; }
        public int Gauteng { get; set; }
        public int KwazuluNatal { get; set; }
        public int Limpopo { get; set; }
        public int Mpumalanga { get; set; }
        public int NorthernCape { get; set; }
        public int NorthWest { get; set; }
        public int WesternCape { get; set; }
    }
}

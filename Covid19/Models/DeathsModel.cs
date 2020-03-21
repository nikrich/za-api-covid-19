using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class DeathsModel
    {
        public int CaseId { get; set; }
        public DateTime Date { get; set; }
        public string DatePlain { get; set; }
    }
}

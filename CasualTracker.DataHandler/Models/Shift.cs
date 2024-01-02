using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.DataHandler.Models
{
    public class Shift
    {
        public DateOnly Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Workplace Workplace { get; set; }
        public  User User { get; set; }

    }
}

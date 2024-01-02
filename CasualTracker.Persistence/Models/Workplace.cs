using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.Persistence.Models
{
    public class Workplace
    {
        [PrimaryKey, AutoIncrement ]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}

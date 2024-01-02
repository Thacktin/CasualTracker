﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.Persistence.Models
{
    public class Shift
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkplaceId { get; set; }
        public int UserID{ get; set; }

    }
}

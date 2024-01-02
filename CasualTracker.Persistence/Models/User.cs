using System;
using SQLite;

namespace CasualTracker.Persistence.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement ]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}

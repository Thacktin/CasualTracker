using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasualTracker.Persistence.Models;

namespace CasualTracker.Persistence
{

    public interface ICasualTrackerPersistence
    {


        public Task<User> GetAllUsers();
        public Task<List<Shift>> GetAllShifts();
        public List<Workplace> GetAllWorkplaces();
    }
}

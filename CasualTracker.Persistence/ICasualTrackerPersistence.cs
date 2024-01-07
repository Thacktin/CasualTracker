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
        void AddShift(Shift shift);
        void AddWorkplace(Workplace workplace);
        public List<Shift> GetAllShifts();
        public List<Workplace> GetAllWorkplaces();
        Workplace GetWorkplaceByShift(Shift selectedShift);

        public void SaveFiles();
    }
}

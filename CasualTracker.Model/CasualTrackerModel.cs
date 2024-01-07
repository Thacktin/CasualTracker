using CasualTracker.Persistence;
using CasualTracker.Persistence.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.Model
{
    public class CasualTrackerModel
    {
        ICasualTrackerPersistence Persistence;

        public Shift selectedShift;

        public event EventHandler? ShiftSelected;
        public event EventHandler? ReturnPreviousPage;
        public event EventHandler? LoadWorkplacePage;
        //public event EventHandler? SwipedToGoBack;
        public CasualTrackerModel(ICasualTrackerPersistence persistence)
        {
            Persistence = persistence;
            //LoadData();
        }


        //public Task<User> GetCurrentUser()
        //{
        //    return  Persistence.GetAllUsers();
        //}

        public void SaveData()
        {
            Persistence.SaveFiles();
        }

        //public bool CheckLoggedIn()
        //{
        //    return GetCurrentUser().Result == null;
        //}

        public List<Shift> GetUserShifts()
        {
            return Persistence.GetAllShifts();
        }

        public void AddShift(Shift shift)
        {
            Persistence.AddShift(shift);
        }

        public void GetShiftByID(Shift? shift)
        {
            this.selectedShift = shift;
            ShiftSelected?.Invoke(this, EventArgs.Empty);
        }

        public void ReturnToPreviousPage()
        {
            ReturnPreviousPage?.Invoke(this, EventArgs.Empty);
        }

        public List<Shift> GetUndoneShiftsOrderedByDate()
        {
            return Persistence.GetAllShifts().Where(x=>x.Date >= DateOnly.FromDateTime(DateTime.Now)).OrderBy(x => x.Date).Take(10).ToList();
        }

        public Workplace GetSelectedShiftWorkplace()
        {
            return Persistence.GetWorkplaceByShift(this.selectedShift);
        }

        public List<Workplace> GetWorkplaces()
        {
            return Persistence.GetAllWorkplaces().ToList();
        }

        public void GetWorkplacePage()
        {
            LoadWorkplacePage.Invoke(this, EventArgs.Empty);
        }

        public void AddWorkplace(Workplace workplace)
        {
            Persistence.AddWorkplace(workplace);
        }

    }
}

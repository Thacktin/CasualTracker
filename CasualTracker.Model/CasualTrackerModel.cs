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

        public event EventHandler? ShiftAdded;
        public event EventHandler? WorkplaceAdded;
        //public event EventHandler? ReturnPreviousPage;
        //public event EventHandler? LoadWorkplacePage;
        public event EventHandler? ShiftsLoaded;
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

        public void LoadData()
        {
            Persistence.LoadFiles();
            ShiftsLoaded?.Invoke(this, EventArgs.Empty);
        }

        //public bool CheckLoggedIn()
        //{
        //    return GetCurrentUser().Result == null;
        //}

        public List<Shift> GetUserShifts()
        {
            return Persistence.GetAllShifts();
        }



        public void GetShiftByID(Shift? shift)
        {
            this.selectedShift = shift;
            //ShiftSelected?.Invoke(this, EventArgs.Empty);
        }

        //public void ReturnToPreviousPage()
        //{
        //     ReturnPreviousPage?.Invoke(this, EventArgs.Empty);
        //}

        public List<Shift> GetUndoneShiftsOrderedByDate()
        {
            return Persistence.GetAllShifts().Where(x=>x.Date >= DateOnly.FromDateTime(DateTime.Now)).OrderBy(x => x.Date).Take(10).ToList();
        }

        //public Workplace GetSelectedShiftWorkplace()
        //{
        //    return Persistence.GetWorkplaceByShift(this.selectedShift);
        //}

        public List<Workplace> GetWorkplaces()
        {
            return Persistence.GetAllWorkplaces().ToList();
        }

        //public void GetWorkplacePage()
        //{
        //    LoadWorkplacePage.Invoke(this, EventArgs.Empty);
        //}

        public void AddWorkplace(string name, string adress)
        {
            Workplace workplace = new Workplace()
            {
                Name = name,
                Adress = adress,
            };
            Persistence.AddWorkplace(workplace);
            WorkplaceAdded?.Invoke(this, EventArgs.Empty);
        }

        public void LoadShifts()
        {
            ShiftsLoaded?.Invoke(this, EventArgs.Empty);
        }

        public Workplace GetWorkplaceForShift(Shift shift)
        {
            return Persistence.GetWorkplaceByShift(shift);
        }

        public void AddShift(DateTime selectedDate, TimeSpan startDate, TimeSpan endDate, Workplace selectedItem)
        {
            Shift shift = new Shift()
            {
                Date = DateOnly.FromDateTime(selectedDate),
                StartTime = TimeOnly.FromTimeSpan(startDate),
                EndTime = TimeOnly.FromTimeSpan(endDate),
                WorkplaceId = selectedItem.ID
            };
            Persistence.AddShift(shift);
            ShiftAdded?.Invoke(this, EventArgs.Empty);

        }

        //public async Task GetShiftAsync(int iD)
        //{
        //    List<Shift> shifts = Persistence.GetAllShifts();
        //    selectedShift = shifts.FirstOrDefault(x=> x.ID == iD);
        //    ShiftSelected?.Invoke(this, EventArgs.Empty);
        //}
    }
}

using CasualTracker.Persistence;
using CasualTracker.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.Model
{
    public class CasualTrackerModel
    {
        ICasualTrackerPersistence Persistence;
        //public Task<User> Users;
        //List<Shift> Shifts;
        //List<Workplace> Workplaces;

        public event EventHandler? ShiftSelected;
        public CasualTrackerModel(ICasualTrackerPersistence persistence)
        {
            Persistence = persistence;
            //LoadData();
        }


        public Task<User> GetCurrentUser()
        {
            return  Persistence.GetAllUsers();
        }

        public void SaveData()
        {
            //DataHandler.AddUser(new() { Name = "alma", Id = 23 });
            //DataHandler.SaveAllChanges();
        }

        public bool CheckLoggedIn()
        {
            return GetCurrentUser().Result == null;
        }

        public async Task< List<Shift>> GetUserShifts()
        {
            return await Persistence.GetAllShifts();
        }

        public void AddShift()
        {
            throw new NotImplementedException();
        }
    }
}

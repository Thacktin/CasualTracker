using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CasualTracker.DataHandler.Models;

namespace CasualTracker.DataHandler
{
    public interface IDataHandler
    {
        public List<User> GetAllUsers();
        public List<Shift> GetAllShifts();
        public List<Workplace> GetAllWorkplaces();
        public List<Shift> GetUserShifts(User user);

        public void AddUser(User user);
        public void ConnectToDB();

        public void SaveAllChanges();

    }
}

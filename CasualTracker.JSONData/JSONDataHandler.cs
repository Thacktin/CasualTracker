using CasualTracker.Data;
using CasualTracker.Data.Models;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.JSONData
{
    public class JSONDataHandler : IDataHandler
    {
        public List<User> Users { get; private set; }
        public List<Shift> Shifts { get; private set; }
        public List<Workplace> Workplaces { get; private set; }

        public void ConnectToDB()
        {
            string usersFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.dat"); ;
            string shiftsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "shifts.dat"); ;
            string workplacesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "workplaces.dat");
            LoadFiles(usersFile, shiftsFile, workplacesFile);
            if (Users == null)
            {
                Users = new();
            }      

            if (Shifts == null)
            {
                Shifts = new();
            }     

            if (Workplaces == null)
            {
                Workplaces = new();
            }
        }

        public void SaveAllChanges()
        {
            string usersFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.dat"); ;
            string shiftsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "shifts.dat"); ;
            string workplacesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "workplaces.dat");
            SaveFiles(usersFile, shiftsFile, workplacesFile);
        }


        public List<Shift> GetAllShifts()
        {
            return this.Shifts;
        }

        public List<User> GetAllUsers()
        {
            return this.Users;
        }

        public List<Shift> GetUserShifts(User user)
        {
            return this.Shifts.Where(s=> s.User == user).ToList();
        }



        private void LoadFiles(string usersFile, string shiftsFile, string workplacesFile)
        {
            if (File.Exists(usersFile))
            {
                string json = File.ReadAllText(usersFile);
                Users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            if (File.Exists(shiftsFile))
            {
                string json = File.ReadAllText(shiftsFile);
                Shifts = JsonConvert.DeserializeObject<List<Shift>>(json);
            }

            if (File.Exists(workplacesFile))
            {
                string json = File.ReadAllText(shiftsFile);
                Workplaces = JsonConvert.DeserializeObject<List<Workplace>>(json);
            }
        }

        private void SaveFiles(string usersFile, string shiftsFile, string workplacesFile)
        {
            string json = JsonConvert.SerializeObject(Users);
            File.WriteAllTextAsync(usersFile, json);         
            
            json = JsonConvert.SerializeObject(Shifts);
            File.WriteAllTextAsync(shiftsFile, json);    

            json = JsonConvert.SerializeObject(Workplaces);
            File.WriteAllTextAsync(workplacesFile, json);
        }

        public void AddUser(User user)
        {
            this.Users.Add(user);
        }
    }
}

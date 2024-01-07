using CasualTracker.Persistence.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.Persistence
{
    public class JSONPersistence : ICasualTrackerPersistence
    {
        string WorkplacesFileName;
        string ShiftsFileName;

        List<Shift> shifts = new();
        List<Workplace> workplaces = new();


        public JSONPersistence(string workplacesFileName, string shiftsfileName)
        {
            WorkplacesFileName = workplacesFileName;
            ShiftsFileName = shiftsfileName;
            //Reset "Database"
            //SaveFiles();
            LoadFiles();
        }

        private void LoadFiles()
        {
            string workplaceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WorkplacesFileName);
            if (File.Exists(workplaceFile))
            {
                workplaces = JsonConvert.DeserializeObject<List<Workplace>>(File.ReadAllText(workplaceFile));
            }

            string shiftsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ShiftsFileName);
            if (File.Exists(shiftsFile))
            {
                shifts = JsonConvert.DeserializeObject<List<Shift>>(File.ReadAllText(shiftsFile));
            }

            if (workplaces == null) workplaces = new();
            if (shifts == null) shifts = new();
        }

       public async void SaveFiles()
        {
            string workplaceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WorkplacesFileName);
            string jsonWorkplace = JsonConvert.SerializeObject(workplaces);
            await File.WriteAllTextAsync(workplaceFile, jsonWorkplace);

            string shiftsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ShiftsFileName);
            string jsonShifts = JsonConvert.SerializeObject(shifts);
            await File.WriteAllTextAsync(shiftsFile, jsonShifts);
        }

        public void AddShift(Shift shift)
        {
            if (shifts.Count > 0)
            {
                shift.ID = shifts.Max(x => x.ID) + 1;
            }
            else
            {
                shift.ID = 0;
            }
            this.shifts.Add(shift);
        }

        public void AddWorkplace(Workplace workplace)
        {
            if (workplaces.Count >0)
            {
                workplace.ID = workplaces.Max(x => x.ID) + 1;
            }
            else
            {
                workplace.ID = 0;
            }

            this.workplaces.Add(workplace);
        }

        public List<Shift> GetAllShifts()
        {
            return this.shifts;
        }

        public List<Workplace> GetAllWorkplaces()
        {
            return this.workplaces;
        }

        public Workplace GetWorkplaceByShift(Shift selectedShift)
        {
            return workplaces.FirstOrDefault(x => x.ID == selectedShift.WorkplaceId,null);
        }
    }
}

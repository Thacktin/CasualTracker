using CasualTracker.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.ViewModel
{
    public class ShiftsViewModel : BindingSource
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartDate { get; set; }
        public TimeOnly EndDate { get; set; }
        public string Adress { get; set; }
        public string WorkplaceName { get; set; }
        public DelegateCommand SelectCommand { get; set; }
        public DelegateCommand ReturnCommand { get; set; }
        public DelegateCommand EditShiftCommand { get; set; }

        public ShiftsViewModel(Shift shift,Workplace workplace ,DelegateCommand selectCommand, DelegateCommand returnCommand, DelegateCommand editShiftCommand)
        {
            ID = shift.ID;
            Date = shift.Date;
            StartDate = shift.StartTime;
            EndDate = shift.EndTime;
            Adress = workplace.Adress;
            WorkplaceName = workplace.Name;
            SelectCommand = selectCommand;
            ReturnCommand = returnCommand;
            EditShiftCommand = editShiftCommand;

        }

    }
}

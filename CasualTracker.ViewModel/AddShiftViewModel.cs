using CasualTracker.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.ViewModel
{

    public class AddShiftViewModel : BindingSource
    {
        public DelegateCommand ReturnCommand { get; private set; }
        public DelegateCommand AddShiftCommand { get; private set; }
        public DelegateCommand AddWorkplacePageCommand { get; private set; }
        public DateTime SelectedDate { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }
        public Workplace SelectedItem { get; set; }
        public List<Workplace>? Workplaces { get; set; }

        public AddShiftViewModel(List<Workplace> workplaces, DelegateCommand returnCommand, DelegateCommand addShiftCommand, DelegateCommand addWorkplaceCommand)
        {
            ReturnCommand = returnCommand;
            AddShiftCommand = addShiftCommand;
            AddWorkplacePageCommand = addWorkplaceCommand;
            SelectedDate = DateTime.Now;
            this.Workplaces = workplaces;
        }


    }
}

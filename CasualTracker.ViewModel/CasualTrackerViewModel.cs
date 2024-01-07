using CasualTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.ViewModel
{
    public class CasualTrackerViewModel : BindingSource
    {
        private CasualTrackerModel model;

        private ShiftsViewModel selectedShift;

        public ObservableCollection<ShiftsViewModel> Shifts { get; set; } = new();

        public ShiftsViewModel SelectedShift
        {
            get => selectedShift;
            private set
            {
                if (value != selectedShift)
                {
                    selectedShift = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand SelectCommand { get; private set; }

        public CasualTrackerViewModel(CasualTrackerModel model)
        {
            this.model = model;
            SelectCommand = new DelegateCommand(Command_Select);
        }

        private void Command_Select(object? param)
        {
            if (param != null && param is ShiftsViewModel shift)
            {
                SelectedShift = shift;
                model.GetShiftAsync(shift.ID);
            }
        }
    }
}

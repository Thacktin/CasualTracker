using CasualTracker.Model;
using CasualTracker.Persistence.Models;
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
        private void Model_ShiftsLoaded(object? sender, EventArgs e)
        {
            foreach (var item in model.GetUndoneShiftsOrderedByDate())
            {
                Workplace workplace = model.GetWorkplaceForShift(item);
                Shifts.Add(new ShiftsViewModel(item, workplace, new DelegateCommand(Command_Select), new DelegateCommand(Command_Return)));
            }

        }

        public event EventHandler? ShiftSelected;
        public event EventHandler? ShiftsLoaded;
        public event EventHandler? ReturnRequested;
        public event EventHandler? ShiftAddRequested;


        public CasualTrackerViewModel(CasualTrackerModel model)
        {
            this.model = model;
            model.ShiftsLoaded += Model_ShiftsLoaded;
            SelectCommand = new DelegateCommand(Command_Select);
            AddShiftCommand = new DelegateCommand(Command_AddShift);
            ReturnCommand = new DelegateCommand(Command_Return);

            this.model.LoadShifts();
        }

        #region Commands
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand AddShiftCommand { get; private set; }
        public DelegateCommand ReturnCommand { get; private set; }

        private void Command_Return(object? obj)
        {
            OnReturn();
        }

        private void Command_AddShift(object? obj)
        {
            OnShiftAdd();
        }

        private void Command_Select(object? param)
        {
            if (param != null && param is ShiftsViewModel shift)
            {
                SelectedShift = shift;
                OnShiftSelected();
            }
        }
        #endregion
        private void OnShiftSelected() => ShiftSelected?.Invoke(this, EventArgs.Empty);
        private void OnReturn() => ReturnRequested?.Invoke(this, EventArgs.Empty);

        private void OnShiftAdd()=> ShiftAddRequested?.Invoke(this, EventArgs.Empty);
    }
}

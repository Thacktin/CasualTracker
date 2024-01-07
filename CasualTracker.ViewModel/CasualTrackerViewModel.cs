using CasualTracker.Model;
using CasualTracker.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.ViewModel
{
    public class CasualTrackerViewModel : BindingSource
    {
        private CasualTrackerModel Model;

        private ShiftsViewModel selectedShift;

        private AddShiftViewModel newShift;
        public AddShiftViewModel AddShiftPage;

        public ObservableCollection<ShiftsViewModel> Shifts { get; set; } = new();
        public AddShiftViewModel NewShift
        {
            get => newShift;
            private set
            {
                if (value != newShift)
                {
                    newShift = value;
                    OnPropertyChanged();
                }
            }
        }

        private AddWorkplaceViewModel workplace;
        public AddWorkplaceViewModel NewWorkplace
        {
            get => workplace;
            private set
            {
                if (value != workplace)
                {
                    workplace = value;
                    OnPropertyChanged();
                }
            }
        }

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
        private void DisplayShiftsList(object? sender, EventArgs e)
        {
            Shifts.Clear();
            List<Shift> shifts = Model.GetUndoneShiftsOrderedByDate();
            if (!shifts.Contains(null))
            {
                foreach (var shift in shifts)
                {

                    Workplace workplace = Model.GetWorkplaceForShift(shift);
                    Shifts.Add(new ShiftsViewModel(shift, workplace, new DelegateCommand(Command_Select), new DelegateCommand(Command_Return)));
                }
            }
        }

        public event EventHandler? ShiftSelected;
        public event EventHandler? ShiftsLoaded;
        public event EventHandler? ReturnRequested;
        public event EventHandler? ShiftAddPageRequested;
        public event EventHandler? ShiftAdded;
        public event EventHandler? WorkplaceAddPageRequested;
        public event EventHandler? WorkplaceAdded;


        public CasualTrackerViewModel(CasualTrackerModel model)
        {
            this.Model = model;
            Model.ShiftsLoaded += DisplayShiftsList;
            Model.ShiftAdded += DisplayShiftsList;
            SelectCommand = new DelegateCommand(Command_Select);
            AddShiftPageCommand = new DelegateCommand(Command_GoToAddShiftPage);
            AddShiftCommand = new DelegateCommand(Command_AddShift);
            //EditShiftCommand = new DelegateCommand(Command_EditShift);
            AddWorkplacePageCommand = new DelegateCommand(Command_GoToAddWorkplacePage);
            AddWorkplaceCommand = new DelegateCommand(Command_AddWorkplace);
            ReturnCommand = new DelegateCommand(Command_Return);

            this.Model.LoadShifts();

        }




        #region Commands
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand AddShiftPageCommand { get; private set; }
        public DelegateCommand AddWorkplacePageCommand { get; private set; }
        public DelegateCommand AddShiftCommand { get; private set; }
        //public DelegateCommand EditShiftCommand { get; private set; }
        public DelegateCommand AddWorkplaceCommand { get; private set; }
        public DelegateCommand ReturnCommand { get; private set; }

        private void Command_Return(object? obj)
        {
            OnReturn();
        }

        private void Command_GoToAddShiftPage(object? obj)
        {
            NewShift = new AddShiftViewModel(Model.GetWorkplaces(), new DelegateCommand(Command_Return), new DelegateCommand(Command_AddShift), new DelegateCommand(Command_GoToAddWorkplacePage));
            OnShiftAddPageRequest();
        }

        private void Command_AddShift(object? param)
        {
            if (param != null && param is AddShiftViewModel shift)
            {

                NewShift.SelectedDate = shift.SelectedDate;
                NewShift.StartDate = shift.StartDate;
                NewShift.EndDate = shift.EndDate;
                newShift.SelectedItem = shift.SelectedItem;
                Debug.WriteLine(shift.SelectedDate.ToString());
                Debug.WriteLine(shift.StartDate.ToString());
                Debug.WriteLine(shift.EndDate.ToString());
                Debug.WriteLine((shift.SelectedItem as Workplace).Name);
                Model.AddShift(NewShift.SelectedDate, newShift.StartDate, newShift.EndDate, newShift.SelectedItem);
                OnShiftAdded();
            }
        }

        private void Command_GoToAddWorkplacePage(object? obj)
        {
            NewWorkplace = new AddWorkplaceViewModel(new DelegateCommand(Command_Return), new DelegateCommand(Command_AddWorkplace));
            OnWorkplaceAddPageRequest();
            Debug.WriteLine("alma");
        }

        private void Command_AddWorkplace(object? param)
        {
            if (param != null && param is AddWorkplaceViewModel workplace)
            {
                Debug.WriteLine(workplace.Name);
                Debug.WriteLine(workplace.Adress);
                NewWorkplace.Name = workplace.Name;
                NewWorkplace.Adress = workplace.Adress;
                Model.AddWorkplace(NewWorkplace.Name, NewWorkplace.Adress);
                OnWorkplaceAdded();
            }
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
        private void OnShiftAddPageRequest() => ShiftAddPageRequested?.Invoke(this, EventArgs.Empty);
        private void OnShiftAdded() => ShiftAdded?.Invoke(this, EventArgs.Empty);

        private void OnWorkplaceAddPageRequest() => WorkplaceAddPageRequested?.Invoke(this, EventArgs.Empty);
        private void OnWorkplaceAdded()=> WorkplaceAdded?.Invoke(this, EventArgs.Empty);
    }
}

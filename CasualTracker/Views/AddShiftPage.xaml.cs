using CasualTracker.Model;
using CasualTracker.Persistence.Models;

namespace CasualTracker.Views;

public partial class AddShiftPage : ContentPage
{
    Shift shift;
    private CasualTrackerModel model;

	public AddShiftPage(CasualTrackerModel model)
	{
		InitializeComponent();
        this.model = model;
        shift = new Shift();
        workplacePicker.ItemsSource = model.GetWorkplaces();
        workplacePicker.ItemDisplayBinding = new Binding("Name");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //workplacePicker.ItemsSource = model.GetWorkplaces();
        //workplacePicker.ItemDisplayBinding = new Binding("Name");
    }
    private void returnBtn_Clicked(object sender, EventArgs e)
    {
        //Navigation.PopToRootAsync();
        //model.ReturnToPreviousPage();
    }

    private void addBtn_Clicked(object sender, EventArgs e)
    {

        if (endLbl.Time < startLbl.Time)
        {
            DisplayAlert("Invalid time interval", "Can't start shift before ending", "Ok");
            return;
        }

        if (endLbl.Time - startLbl.Time <TimeSpan.FromMinutes(30))
        {
            DisplayAlert("Invalid time interval", "Length can't be less than 30 minutes", "Ok");
            return;
        }

        if (workplacePicker.SelectedItem == null)
        {
            DisplayAlert("Invalid workplace", "Must choose a workplace", "Ok");
            return;
        }

        shift.Date = DateOnly.FromDateTime(dateLbl.Date);
        shift.StartTime = TimeOnly.FromTimeSpan(startLbl.Time);
        shift.EndTime = TimeOnly.FromTimeSpan(endLbl.Time);
        shift.WorkplaceId = (workplacePicker.SelectedItem as Workplace).ID;
        model.AddShift(shift);
        DisplayAlert("", "Shift added", "OK");
        model.SaveData();
        //model.ReturnToPreviousPage();

    }

    private void workplaceBtn_Clicked(object sender, EventArgs e)
    {
        model.GetWorkplacePage();
    }
}
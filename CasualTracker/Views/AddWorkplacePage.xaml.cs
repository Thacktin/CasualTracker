using CasualTracker.Model;
using CasualTracker.Persistence.Models;

namespace CasualTracker.Views;

public partial class AddWorkplacePage : ContentPage
{
	CasualTrackerModel model;
	Workplace workplace;
	public AddWorkplacePage(CasualTrackerModel model)
	{
		InitializeComponent();
		this.model = model;
        this.workplace = new();
    }

    private void returnBtn_Clicked(object sender, EventArgs e)
    {
		//model.ReturnToPreviousPage();
    }

    private void addBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(adressEntry.Text))
        {
            DisplayAlert("Invalid adress", "Adress can't be empty", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(nameEntry.Text))
        {
            DisplayAlert("Invalid name", "Name can't be empty", "Ok");
            return;
        }
        workplace.Adress = adressEntry.Text;
        workplace.Name = nameEntry.Text;
        model.AddWorkplace(workplace);
        DisplayAlert("", "Workplace added", "OK");
        //model.ReturnToPreviousPage();
    }
}
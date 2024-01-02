using CasualTracker.Model;
using CasualTracker.Persistence.Models;

namespace CasualTracker.Views;

public partial class ShiftPage : ContentPage
{
	private CasualTrackerModel Model;
	public ShiftPage(CasualTrackerModel model)
	{
		
		InitializeComponent();
        Model = model;

    }
}
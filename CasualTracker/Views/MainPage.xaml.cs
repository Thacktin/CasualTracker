using CasualTracker.Model;
using CasualTracker.Persistence.Models;
using CasualTracker.Views;
using System.Collections.Generic;
using System.Reflection;

namespace CasualTracker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        CasualTrackerModel Model;
        public MainPage(CasualTrackerModel model)
        {
            Model = model;


            InitializeComponent();
            //foreach (Shift item in Model.GetUserShifts())
            //{
            //    Button btn = new Button()
            //    {
            //        Text = item.StartDate.ToString(),
            //        BindingContext = item.ID,
            //    };
            //    ShiftsList.Children.Add(btn);


            //}
            foreach (Shift item in Model.GetUserShifts().Result.ToList())
            {
                Button btn = new Button()
                {
                    Text = item.StartDate.ToString(),
                    BindingContext = item.ID,
                };
                ShiftsList.Children.Add(btn);


            }

        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            //dataLbl.Text = $"Hello {Model.GetCurrentUser().Result?.Name}!";
            ///dataLbl.Text = Model.GetCurrentUser().Result.Name;
            ///

        }



        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Model.SaveData();
        }

        private async void addShiftBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddShiftPage());
        }

    }

}

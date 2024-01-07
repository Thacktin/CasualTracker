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
            //foreach (Shift item in Model.GetUserShifts())
            //{
            //    Button btn = new Button()
            //    {
            //        Text = item.StartTime.ToString(),
            //        BindingContext = item.ID,
            //    };
            //    ShiftsList.Children.Add(btn);


            //}

        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            ShiftsList.Clear();
            foreach (Shift item in Model.GetUndoneShiftsOrderedByDate())
            {
                Button btn = new Button()
                {
                    Text = $"{item.Date.ToString()} {item.StartTime.ToString()}",
                    BindingContext = item,
                    Padding = 5,
                    BackgroundColor = Color.FromHex("42f54e"),
                };
                btn.Clicked += Btn_Clicked;
                ShiftsList.Children.Add(btn);


            }
        }

        private void Btn_Clicked(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            Shift shift = button.BindingContext as Shift;
            Model.GetShiftByID(shift);
        }

        //private void SaveBtn_Clicked(object sender, EventArgs e)
        //{

        //    Model.SaveData();
        //}

        private async void addShiftBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddShiftPage(Model));
        }

    }

}

using CasualTracker.Model;
using CasualTracker.Persistence;
using CasualTracker.Services;
using CasualTracker.ViewModel;
using CasualTracker.Views;
namespace CasualTracker
{
    public partial class App : Application
    {
        CasualTrackerModel Model;
        ICasualTrackerPersistence Persistence;
        NavigationPage Rootpage;
        CasualTrackerViewModel ViewModel;
        public static IServiceProvider Services;
        public static IAlertService AlertSvc;
        public App(IServiceProvider provider)
        {
            InitializeComponent();
            Services = provider;
            AlertSvc = Services.GetService<IAlertService>();

            Persistence = new JSONPersistence("shifts.data", "workplaces.data");
            Model = new CasualTrackerModel(Persistence);
            ViewModel = new CasualTrackerViewModel(Model);

            ViewModel.ShiftSelected += ViewModel_ShiftSelected;
            ViewModel.ReturnRequested += ViewModel_ReturnPreviousPage;
            //Model.LoadWorkplacePage += Model_LoadWorkplacePage;
            ViewModel.ShiftAddPageRequested += ViewModel_ShiftAddRequested;
            ViewModel.ShiftAdded += ViewModel_ShiftAdded;
            ViewModel.WorkplaceAdded += ViewModel_WorkplaceAdded;
            ViewModel.WorkplaceAddPageRequested += ViewModel_WorkplaceAddPageRequested;
            ViewModel.ArgumentError += ViewModel_ArgumentError;

            Rootpage = new NavigationPage(new MainPage(Model));
            Rootpage.BindingContext = ViewModel;
            MainPage = Rootpage;

        }

        private void ViewModel_ArgumentError(object? sender, EventArgs e)
        {
            ArgumentErrorEventArgs args = (ArgumentErrorEventArgs)e;
            Task.Run(async () =>
            {
                await Task.Delay(250);
                App.AlertSvc.ShowAlert(args.Error, args.Message, args.ButtonText);
                //App.AlertSvc.ShowConfirmation(args.Message, args.ButtonText, (result =>
                //{
                //    App.AlertSvc.ShowAlert("Result", $"{result}");
                //}));
            });
        }

        private async void ViewModel_WorkplaceAdded(object? sender, EventArgs e)
        {
            await Rootpage.PopAsync();
        }

        private async void ViewModel_WorkplaceAddPageRequested(object? sender, EventArgs e)
        {
            if (!(Rootpage.CurrentPage is AddWorkplacePage))
            {
                await Rootpage.PushAsync(new AddWorkplacePage(Model));
            }
        }

        private async void ViewModel_ShiftAdded(object? sender, EventArgs e)
        {
            Model.SaveData();
            await Rootpage.PopAsync();
        }

        private async void ViewModel_ShiftAddRequested(object? sender, EventArgs e)
        {
            if (!(Rootpage.CurrentPage is AddShiftPage))
            {
                await Rootpage.PushAsync(new AddShiftPage());
            }

        }

        //private async void Model_LoadWorkplacePage(object? sender, EventArgs e)
        //{
        //    await Rootpage.PushAsync(new AddWorkplacePage(Model));
        //}

        private async void ViewModel_ReturnPreviousPage(object? sender, EventArgs e)
        {
            await Rootpage.PopAsync();
        }

        private async void ViewModel_ShiftSelected(object? sender, EventArgs e)
        {
            if (!(Rootpage.CurrentPage is ShiftPage))
            {
                await Rootpage.Navigation.PushAsync(new ShiftPage());
            }

        }

        protected override async void OnStart()
        {
            Model.LoadData();
            base.OnStart();

        }
        protected override async void OnSleep()
        {
            Model.SaveData();
            base.OnSleep();
        }
        protected override async void OnResume()
        {
            Model.LoadData();
            base.OnResume();
        }

    }
}


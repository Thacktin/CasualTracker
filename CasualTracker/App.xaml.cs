using CasualTracker.Model;
using CasualTracker.Persistence;
using CasualTracker.ViewModel;
using CasualTracker.Views;
namespace CasualTracker
{
    public partial class App : Application
    {
        CasualTrackerModel Model;
        ICasualTrackerPersistence Persistence;
        NavigationPage Rootpage;
        CasualTrackerViewModel viewModel;
        public App() 
        {
            InitializeComponent();
            Persistence = new JSONPersistence("shifts.dat", "workplaces.dat");
            Model = new CasualTrackerModel(Persistence);
            viewModel = new CasualTrackerViewModel(Model);

            viewModel.ShiftSelected += ViewModel_ShiftSelected;
            viewModel.ReturnRequested += ViewModel_ReturnPreviousPage;
            Model.LoadWorkplacePage += Model_LoadWorkplacePage;
            viewModel.ShiftAddRequested += ViewModel_ShiftAddRequested;

            Rootpage = new NavigationPage(new MainPage(Model));
            Rootpage.BindingContext = viewModel;
            MainPage = Rootpage;

        }

        private async void ViewModel_ShiftAddRequested(object? sender, EventArgs e)
        {
            await Rootpage.PushAsync(new AddShiftPage(Model));
        }

        private async void Model_LoadWorkplacePage(object? sender, EventArgs e)
        {
            await Rootpage.PushAsync(new AddWorkplacePage(Model));
        }

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

        protected override void OnStart()
        {
            base.OnStart();
            //Model.LoadData();
        }



    }
}

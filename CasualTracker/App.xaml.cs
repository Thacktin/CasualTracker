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
            Persistence = new JSONPersistence("shifts.data", "workplaces.data");
            Model = new CasualTrackerModel(Persistence);
            viewModel = new CasualTrackerViewModel(Model);

            viewModel.ShiftSelected += ViewModel_ShiftSelected;
            viewModel.ReturnRequested += ViewModel_ReturnPreviousPage;
            //Model.LoadWorkplacePage += Model_LoadWorkplacePage;
            viewModel.ShiftAddPageRequested += ViewModel_ShiftAddRequested;
            viewModel.ShiftAdded += ViewModel_ShiftAdded;
            viewModel.WorkplaceAdded += ViewModel_WorkplaceAdded;
            viewModel.WorkplaceAddPageRequested += ViewModel_WorkplaceAddPageRequested;

            Rootpage = new NavigationPage(new MainPage(Model));
            Rootpage.BindingContext = viewModel;
            MainPage = Rootpage;

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

        //protected override void OnStart()
        //{
        //    base.OnStart();
        //    //Model.LoadData();
        //}



    }
}
